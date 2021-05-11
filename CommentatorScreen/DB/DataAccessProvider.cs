using System.Collections.Generic;
using System.Linq;

namespace CommentatorScreen
{
    /// <summary>
    /// Class for accessing the database
    /// </summary>
    public class DataAccessProvider : IDataAcessProvider
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly racenetdbContext context;

        #region Constructor

        public DataAccessProvider(racenetdbContext racenetContext)
        {
            context = racenetContext;
        }

        #endregion Constructor

        #region Functions

        /// <summary>
        /// Get the runlog from the database
        /// </summary>
        /// <returns>Rn_runlog as a list</returns>
        public List<RnRunlog> GetRunlog()
        {
            return context.RnRunlogs.OrderByDescending(r => r.Runid).ToList();
        }

        /// <summary>
        /// Get the runlog from the database
        /// where racenumber or driver name matches
        /// </summary>
        /// <returns>Rn_runlog as a list</returns>
        public List<RnRunlog> GetRunlogByRacenumber(string drivername)
        {
            return context.RnRunlogs.OrderByDescending(r => r.Runid).
                Where(r => r.Racenum.Trim().Contains(drivername.Trim())).ToList();
        }

        /// <summary>
        /// Get category from db using the id
        /// </summary>
        /// <param name="id">Id of the desired category</param>
        public RnCateg GetCategory(int id)
        {
            return context.RnCategs.Where(cat => cat.Id == id).First();
        }

        /// <summary>
        /// Get the current active catgory from the DB
        /// </summary>
        public RnCateg GetCurrentCategory()
        {
            int id = GetCurrentCategoryId();
            return GetCategory(id);
        }

        /// <summary>
        /// Get the current active catgories ID from the DB
        /// </summary>
        /// <returns>The id of the current category</returns>
        public int GetCurrentCategoryId()
        {
            RnConfig configs = context.RnConfigs.First();
            return configs.CurrentCategory;
        }

        public List<QualifyingRun> GetCurrentQualifying(int id)
        {
            // Get a list of all qualifying runs + driver files
            List<QualifyingRun> qualifyingAttempts = new(context.RnQuals.Where(q => q.Category == id).Join
                (
                    context.RnRacers,
                    quals => quals.Racenum,
                    racers => racers.Racenum,
                    (quals, racers) => new QualifyingRun
                    {
                        DriverName = racers.Driver,
                        Et = quals.Et,
                        Speed = quals.Speed,
                        Reaction = quals.Reaction,
                        Racenum = quals.Racenum
                    }).ToList());

            // Process of removing all addtional runs
            // List to store racenumbers and
            // list to store indexs of extra runs
            List<string> racenumbers = new();
            List<int> removeIndex = new();

            // Loop through runs
            int i = 0;
            foreach (var item in qualifyingAttempts)
            {
                // If race number already in list
                if (racenumbers.Contains(item.Racenum))
                {
                    // Store its location for removal
                    removeIndex.Add(i);
                    i--;
                }
                else
                {
                    // Add its racenumber to list
                    racenumbers.Add(item.Racenum);
                }
                i++;
            }

            //Loop each index and remove them
            foreach (var item in removeIndex)
            {
                qualifyingAttempts.RemoveAt(item);
            }

            return qualifyingAttempts;
        }

        /// <summary>
        /// Get all incremental information from the prediction model
        /// </summary>
        /// <returns>incremental information</returns>
        public CnnCurrentpair GetCurrentPair()
        {
            //TODO CLEAN THIS
            List<CnnCurrentpair> cnnCurrentpairs = context.CnnCurrentpairs.ToList();
            if (cnnCurrentpairs.Count != 0)
            {
                return cnnCurrentpairs[^1];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the current pairs racenumbers
        /// </summary>
        /// <returns></returns>
        public string[] GetCurrentPairRacenumbers()
        {
            // Get all current pair information
            CnnCurrentpair currentPair = GetCurrentPair();

            string[] racenumbers = new string[2];

            if (currentPair != null)
            {
                // Store the current pairs race numbers
                racenumbers[0] = currentPair.Leftracenum;
                racenumbers[1] = currentPair.Rightracenum;

                return racenumbers;
            }

            racenumbers[0] = "";
            racenumbers[1] = "";

            return racenumbers;
        }

        /// <summary>
        /// Gets the next pairs racenumbers
        /// </summary>
        /// <returns></returns>
        public string[] GetNextPairRacenumbers()
        {
            // Get all current pair information
            CnnCurrentpair currentPair = GetCurrentPair();

            // Store the current pairs race numbers
            string[] racenumbers = new string[2];

            if (currentPair != null)
            {
                racenumbers[0] = currentPair.Leftnextracenum;
                racenumbers[1] = currentPair.Rightnextracenum;

                return racenumbers;
            }

            racenumbers[0] = "";
            racenumbers[1] = "";

            return racenumbers;
        }

        /// <summary>
        /// Get the current selected mode
        /// </summary>
        /// <returns></returns>
        public string GetMode()
        {
            return context.RnConfigs.First().Mode;
        }

        /// <summary>
        /// Gets a racers driver file
        /// </summary>
        /// <param name="categoryId">Category of the racer</param>
        /// <param name="racenumber">Race number of the racer</param>
        /// <returns></returns>
        public RnRacer GetDriverFile(int categoryId, string racenumber)
        {
            RnRacer racer = context.RnRacers.Where(
                r => r.Category == categoryId &&
                r.Racenum == racenumber
                ).FirstOrDefault();

            //If null, driver files doesnt exist
            if (racer == null)
            {
                // Create a new temp driver file,
                // Set the racenumber
                racer = new RnRacer
                {
                    Racenum = racenumber
                };
            }

            return racer;
        }

        /// <summary>
        /// List for get all the runs of one driver
        /// NOTE: THIS METHOD ASSUMES THAT A DRIVER
        /// HAS HAD THE SAME TRACK LENGTH FOR ALL RUNS
        /// </summary>
        /// <param name="categoryid">Category of the driver</param>
        /// <param name="racenum">Racenumber of the driver</param>
        /// <returns></returns>
        public List<RacerHistoryRun> GetDriverHistory(int categoryid, string racenum)
        {
            List<RacerHistoryRun> runlog = null;

            // Get the first run id of the driver
            // Which also check the driver has a history
            RnRunlog firstRun = GetFirstRunOfDriver(categoryid, racenum);

            if (firstRun == null)
            {
                return new List<RacerHistoryRun>();
            }

            int firstRunId = firstRun.Runid;

            // Get the track length of a run
            int? trackLength = GetTrackLengthOfRun(firstRunId);

            if (trackLength == null)
            {
                // If there is a masterlister error, use 3 as default
                trackLength = 3;
            }

            switch (trackLength)
            {
                case 3:
                    runlog = context.RnRunlogs
                .Where(r => r.Racenum == racenum && r.Category == categoryid)
                .Select(runlog => new RacerHistoryRun
                {
                    Reaction = runlog.Reaction,
                    Lane = runlog.Lane,
                    ET = runlog.Et1320,
                    MPH = runlog.Speed1320,
                    Index = runlog.Index,
                    Result = runlog.Result
                }).ToList();
                    break;

                case 2:
                    runlog = context.RnRunlogs
                .Where(r => r.Racenum == racenum && r.Category == categoryid)
                .Select(runlog => new RacerHistoryRun
                {
                    Reaction = runlog.Reaction,
                    Lane = runlog.Lane,
                    ET = runlog.Et660,
                    MPH = runlog.Speed660,
                    Index = runlog.Index,
                    Result = runlog.Result
                }).ToList();
                    break;

                case 1:
                    runlog = context.RnRunlogs
                .Where(r => r.Racenum == racenum && r.Category == categoryid)
                .Select(runlog => new RacerHistoryRun
                {
                    Reaction = runlog.Reaction,
                    Lane = runlog.Lane,
                    ET = runlog.Et1000,
                    MPH = runlog.Speed1000,
                    Index = runlog.Index,
                    Result = runlog.Result
                }).ToList();
                    break;

                default:
                    break;
            }

            return runlog.OrderBy(r => r.ET).ToList();
        }

        /// <summary>
        /// Get the tracklength of a run
        /// </summary>
        /// <param name="firstRunId">Id of the run</param>
        /// <returns></returns>
        private int? GetTrackLengthOfRun(int runId)
        {
            return context.RnMasterlists.Where(r => r.Runindex == runId).FirstOrDefault().Tracklength;
        }

        /// <summary>
        /// Gets the run id of the driver
        /// </summary>
        /// <param name="categoryid">Category of the driver</param>
        /// <param name="racenum">Race number of a driver</param>
        /// <returns></returns>
        private RnRunlog GetFirstRunOfDriver(int categoryId, string racenum)
        {
            return context.RnRunlogs.Where(r => r.Racenum == racenum && r.Category == categoryId).FirstOrDefault();
        }

        #endregion Functions
    }
}