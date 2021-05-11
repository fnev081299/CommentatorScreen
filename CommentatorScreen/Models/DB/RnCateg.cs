#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Object for each record in rn_categ
    /// Contains Category setup
    /// Derived from CATEG2.DFN
    /// </summary>
    public partial class RnCateg
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tree Type
        /// 0: .5 FULL,
        /// 1: .4 PRO,
        /// 2: X_OVER,
        /// 3: .5 PRO,
        /// 4: DELAY
        /// </summary>
        public int? Tree { get; set; }

        /// <summary>
        /// Finish Line
        /// 0: 1/4 Mile,
        /// 1: 1/8 Mile,
        /// 2: 1000'
        /// </summary>
        public int? Finish { get; set; }

        /// <summary>
        /// Deep Stage Foul/Super Start enabled
        /// </summary>
        public bool? Dsf { get; set; }

        /// <summary>
        /// Remote Start Mode.
        /// 1: Unknown,
        /// 2: Auto Start,
        /// 3: Remote Disabled,
        /// 4: Remote Start,
        /// 5: Test
        /// </summary>
        public int? Remotestart { get; set; }

        /// <summary>
        /// Time between the final racer staging and
        /// the tree counting down (in seconds)
        /// </summary>
        public decimal? Stagedtostart { get; set; }

        /// <summary>
        /// Number of seconds for the 2nd car to get into stage
        /// after the first car has been in stage before getting
        /// a red light (in seconds)
        /// </summary>
        public int? Pstagedtostaged { get; set; }

        /// <summary>
        /// Stack lock enabled
        /// Can pre-stage, stage, roll back out of stage but keep the stage bulb on
        /// </summary>
        public bool? Stagelock { get; set; }

        /// <summary>
        /// The default index of the category
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// Qualification Mode.
        /// 0: ET (Sportsman Ladder),
        /// 1: ET-DI,
        /// 2: ET-<DI>,
        /// 3: ET (Pro Ladder)
        /// </summary>
        public int? Qualmode { get; set; }

        /// <summary>
        /// The number of spots available in elimations
        /// </summary>
        public int? Bump { get; set; }

        /// <summary>
        /// Team Points Enabled
        /// </summary>
        public bool? Teampoints { get; set; }

        /// <summary>
        ///  If enabled shows the MPH on the scoreboards
        ///  during eliminations when you have an index.
        /// </summary>
        public bool? SbSpeed { get; set; }

        /// <summary>
        /// If enabled the reaction time is shown on the
        /// scorebaords during qualifying and time trials
        /// </summary>
        public bool? SbRt { get; set; }

        /// <summary>
        /// If the category is in breakout, no breakout
        /// 1: No Breakout,
        /// 2: Breakout,
        /// 3: Stock/Super Stock Mode
        /// </summary>
        public int? Breakout { get; set; }

        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Pk { get; set; }
    }
}