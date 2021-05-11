using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CommentatorScreen
{
    public partial class racenetdbContext : DbContext
    {
        public racenetdbContext()
        {
        }

        public racenetdbContext(DbContextOptions<racenetdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AceClass> AceClasses { get; set; }
        public virtual DbSet<CnnCurrentpair> CnnCurrentpairs { get; set; }
        public virtual DbSet<RnCateg> RnCategs { get; set; }
        public virtual DbSet<RnClass> RnClasses { get; set; }
        public virtual DbSet<RnConfig> RnConfigs { get; set; }
        public virtual DbSet<RnCountrycode> RnCountrycodes { get; set; }
        public virtual DbSet<RnDqual> RnDquals { get; set; }
        public virtual DbSet<RnElim> RnElims { get; set; }
        public virtual DbSet<RnEtslip> RnEtslips { get; set; }
        public virtual DbSet<RnLadder> RnLadders { get; set; }
        public virtual DbSet<RnMasterlist> RnMasterlists { get; set; }
        public virtual DbSet<RnQual> RnQuals { get; set; }
        public virtual DbSet<RnRacer> RnRacers { get; set; }
        public virtual DbSet<RnRunlog> RnRunlogs { get; set; }
        public virtual DbSet<RnTrackinfo> RnTrackinfos { get; set; }
        public virtual DbSet<RnTransact> RnTransacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning
                /*
                 * To protect potentially sensitive information in your connection string, you should move it out of source code.
                 * You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration -
                 * see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
                 * see http://go.microsoft.com/fwlink/?LinkId=723263. */
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=racenetdb_test;UserId=postgres;Password=password");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<AceClass>(entity =>
            {
                entity.HasKey(e => e.Letter)
                    .HasName("ace_Classes_pkey");

                entity.ToTable("ace_classes");

                entity.Property(e => e.Letter)
                    .HasMaxLength(3)
                    .HasColumnName("letter")
                    .IsFixedLength(true);

                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<CnnCurrentpair>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cnn_currentpair");

                entity.Property(e => e.Leftet1000)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftet1000");

                entity.Property(e => e.Leftet1320)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftet1320");

                entity.Property(e => e.Leftet330)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftet330");

                entity.Property(e => e.Leftet60)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftet60");

                entity.Property(e => e.Leftet660)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftet660");

                entity.Property(e => e.Leftindex)
                    .HasPrecision(4, 2)
                    .HasColumnName("leftindex");

                entity.Property(e => e.Leftnextindex)
                    .HasPrecision(4, 2)
                    .HasColumnName("leftnextindex");

                entity.Property(e => e.Leftnextracenum)
                    .HasMaxLength(8)
                    .HasColumnName("leftnextracenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Leftracenum)
                    .HasMaxLength(8)
                    .HasColumnName("leftracenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Leftreaction)
                    .HasPrecision(6, 4)
                    .HasColumnName("leftreaction");

                entity.Property(e => e.Leftspeed1000)
                    .HasPrecision(5, 2)
                    .HasColumnName("leftspeed1000");

                entity.Property(e => e.Leftspeed1320)
                    .HasPrecision(5, 2)
                    .HasColumnName("leftspeed1320");

                entity.Property(e => e.Leftspeed660)
                    .HasPrecision(5, 2)
                    .HasColumnName("leftspeed660");

                entity.Property(e => e.Leftstaged)
                    .HasColumnType("character varying")
                    .HasColumnName("leftstaged");

                entity.Property(e => e.Rightet1000)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightet1000");

                entity.Property(e => e.Rightet1320)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightet1320");

                entity.Property(e => e.Rightet330)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightet330");

                entity.Property(e => e.Rightet60)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightet60");

                entity.Property(e => e.Rightet660)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightet660");

                entity.Property(e => e.Rightindex)
                    .HasPrecision(4, 2)
                    .HasColumnName("rightindex");

                entity.Property(e => e.Rightnextindex)
                    .HasPrecision(4, 2)
                    .HasColumnName("rightnextindex");

                entity.Property(e => e.Rightnextracenum)
                    .HasMaxLength(8)
                    .HasColumnName("rightnextracenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Rightracenum)
                    .HasMaxLength(8)
                    .HasColumnName("rightracenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Rightreaction)
                    .HasPrecision(6, 4)
                    .HasColumnName("rightreaction");

                entity.Property(e => e.Rightspeed1000)
                    .HasPrecision(5, 2)
                    .HasColumnName("rightspeed1000");

                entity.Property(e => e.Rightspeed1320)
                    .HasPrecision(5, 2)
                    .HasColumnName("rightspeed1320");

                entity.Property(e => e.Rightspeed660)
                    .HasPrecision(5, 2)
                    .HasColumnName("rightspeed660");

                entity.Property(e => e.Rightstaged)
                    .HasColumnType("character varying")
                    .HasColumnName("rightstaged");

                entity.Property(e => e.Towerready)
                    .HasColumnType("character varying")
                    .HasColumnName("towerready");

                entity.Property(e => e.Tree)
                    .HasMaxLength(20)
                    .HasColumnName("tree")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnCateg>(entity =>
            {
                entity.ToTable("rn_categ");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Breakout).HasColumnName("breakout");

                entity.Property(e => e.Bump).HasColumnName("bump");

                entity.Property(e => e.Dsf).HasColumnName("dsf");

                entity.Property(e => e.Finish).HasColumnName("finish");

                entity.Property(e => e.Index)
                    .HasPrecision(4, 2)
                    .HasColumnName("index");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Pk)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pk");

                entity.Property(e => e.Pstagedtostaged).HasColumnName("pstagedtostaged");

                entity.Property(e => e.Qualmode).HasColumnName("qualmode");

                entity.Property(e => e.Remotestart).HasColumnName("remotestart");

                entity.Property(e => e.SbRt).HasColumnName("sb_rt");

                entity.Property(e => e.SbSpeed).HasColumnName("sb_speed");

                entity.Property(e => e.Stagedtostart)
                    .HasPrecision(2, 1)
                    .HasColumnName("stagedtostart");

                entity.Property(e => e.Stagelock).HasColumnName("stagelock");

                entity.Property(e => e.Teampoints).HasColumnName("teampoints");

                entity.Property(e => e.Tree).HasColumnName("tree");
            });

            modelBuilder.Entity<RnClass>(entity =>
            {
                entity.ToTable("rn_class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Classid).HasColumnName("classid");

                entity.Property(e => e.Index1320)
                    .HasPrecision(4, 2)
                    .HasColumnName("index1320");

                entity.Property(e => e.Index660)
                    .HasPrecision(4, 2)
                    .HasColumnName("index660");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnConfig>(entity =>
            {
                entity.HasKey(e => e.CurrentCategory)
                    .HasName("rn_config_pkey");

                entity.ToTable("rn_config");

                entity.Property(e => e.CurrentCategory).ValueGeneratedNever();

                entity.Property(e => e.Mode)
                    .HasMaxLength(2)
                    .HasColumnName("mode")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnCountrycode>(entity =>
            {
                entity.HasKey(e => e.Twochar)
                    .HasName("rn_countrycodes_pkey");

                entity.ToTable("rn_countrycodes");

                entity.Property(e => e.Twochar)
                    .HasMaxLength(2)
                    .HasColumnName("twochar")
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Threechar)
                    .HasMaxLength(3)
                    .HasColumnName("threechar")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnDqual>(entity =>
            {
                entity.ToTable("rn_dqual");

                entity.Property(e => e.Id)
                    .HasColumnType("oid")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dqindex)
                    .HasMaxLength(5)
                    .HasColumnName("dqindex")
                    .IsFixedLength(true);

                entity.Property(e => e.Reason)
                    .HasMaxLength(30)
                    .HasColumnName("reason")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnElim>(entity =>
            {
                entity.ToTable("rn_elim");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Elimrnd).HasColumnName("elimrnd");

                entity.Property(e => e.Et)
                    .HasPrecision(6, 4)
                    .HasColumnName("et");

                entity.Property(e => e.Index)
                    .HasPrecision(4, 2)
                    .HasColumnName("index");

                entity.Property(e => e.Lane).HasColumnName("lane");

                entity.Property(e => e.Racenum)
                    .HasMaxLength(20)
                    .HasColumnName("racenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Reaction)
                    .HasPrecision(6, 4)
                    .HasColumnName("reaction");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(30)
                    .HasColumnName("remarks")
                    .IsFixedLength(true);

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.Runid).HasColumnName("runid");

                entity.Property(e => e.Speed)
                    .HasPrecision(5, 2)
                    .HasColumnName("speed");
            });

            modelBuilder.Entity<RnEtslip>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rn_etslip");

                entity.Property(e => e.Line).HasColumnName("line");

                entity.Property(e => e.Text)
                    .HasMaxLength(38)
                    .HasColumnName("text")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnLadder>(entity =>
            {
                entity.HasKey(e => new { e.Category, e.Elimrnd, e.Pair })
                    .HasName("rn_ladder_pkey");

                entity.ToTable("rn_ladder");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Elimrnd).HasColumnName("elimrnd");

                entity.Property(e => e.Pair).HasColumnName("pair");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Racenum1)
                    .HasMaxLength(20)
                    .HasColumnName("racenum1")
                    .IsFixedLength(true);

                entity.Property(e => e.Racenum2)
                    .HasMaxLength(20)
                    .HasColumnName("racenum2")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnMasterlist>(entity =>
            {
                entity.HasKey(e => new { e.Runindex, e.Lane })
                    .HasName("rn_masterlist_pkey");

                entity.ToTable("rn_masterlist");

                entity.Property(e => e.Runindex)
                    .HasColumnName("runindex")
                    .HasComment("Run Number");

                entity.Property(e => e.Lane)
                    .HasColumnName("lane")
                    .HasComment("Lane, False=left, True=Right");

                entity.Property(e => e.Aborted)
                    .HasColumnName("aborted")
                    .HasComment("Run Aborted");

                entity.Property(e => e.Amber1)
                    .HasPrecision(5, 3)
                    .HasColumnName("amber1")
                    .HasComment("1st Amber On Time");

                entity.Property(e => e.Amber2)
                    .HasPrecision(5, 3)
                    .HasColumnName("amber2")
                    .HasComment("2nd Amber On Time");

                entity.Property(e => e.Amber3)
                    .HasPrecision(5, 3)
                    .HasColumnName("amber3")
                    .HasComment("3rd Amber On Time");

                entity.Property(e => e.Autostartstagestart)
                    .HasPrecision(3, 2)
                    .HasColumnName("autostartstagestart")
                    .HasComment("AutoStart Staged to Start Time");

                entity.Property(e => e.Autostarttimeout)
                    .HasColumnName("autostarttimeout")
                    .HasComment("AutoStart Time Out");

                entity.Property(e => e.Bkoutmode)
                    .HasColumnName("bkoutmode")
                    .HasComment("Breakout Mode (0=No Breakout, 1=Breakout, 2=SS & S)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasComment("Category Number");

                entity.Property(e => e.Cell10active)
                    .HasColumnName("cell10active")
                    .HasComment("1254' Active");

                entity.Property(e => e.Cell10error)
                    .HasColumnName("cell10error")
                    .HasComment("1254' Error");

                entity.Property(e => e.Cell10quality)
                    .HasColumnName("cell10quality")
                    .HasComment("1254' Quality (%)");

                entity.Property(e => e.Cell10time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell10time")
                    .HasComment("1254' Trigger time");

                entity.Property(e => e.Cell11active)
                    .HasColumnName("cell11active")
                    .HasComment("1320' Active");

                entity.Property(e => e.Cell11error)
                    .HasColumnName("cell11error")
                    .HasComment("1320' Error");

                entity.Property(e => e.Cell11quality)
                    .HasColumnName("cell11quality")
                    .HasComment("1320' Quality (%)");

                entity.Property(e => e.Cell11time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell11time")
                    .HasComment("1320' Trigger time");

                entity.Property(e => e.Cell12active)
                    .HasColumnName("cell12active")
                    .HasComment("1386' Active");

                entity.Property(e => e.Cell12error)
                    .HasColumnName("cell12error")
                    .HasComment("1386' Error");

                entity.Property(e => e.Cell12quality)
                    .HasColumnName("cell12quality")
                    .HasComment("1386' Quality (%)");

                entity.Property(e => e.Cell12time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell12time")
                    .HasComment("1386' Trigger time");

                entity.Property(e => e.Cell1active)
                    .HasColumnName("cell1active")
                    .HasComment("Pre-stage active ");

                entity.Property(e => e.Cell1error)
                    .HasColumnName("cell1error")
                    .HasComment("Pre-Stage Error");

                entity.Property(e => e.Cell1quality)
                    .HasColumnName("cell1quality")
                    .HasComment("Pre-Stage Quality (%)");

                entity.Property(e => e.Cell1time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell1time")
                    .HasComment("Pre-stage remake time");

                entity.Property(e => e.Cell2active)
                    .HasColumnName("cell2active")
                    .HasComment("Stage active");

                entity.Property(e => e.Cell2error)
                    .HasColumnName("cell2error")
                    .HasComment("Stage Error");

                entity.Property(e => e.Cell2quality)
                    .HasColumnName("cell2quality")
                    .HasComment("Stage Quality (%)");

                entity.Property(e => e.Cell2time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell2time")
                    .HasComment("Stage remake time");

                entity.Property(e => e.Cell3active)
                    .HasColumnName("cell3active")
                    .HasComment("Guard active");

                entity.Property(e => e.Cell3error)
                    .HasColumnName("cell3error")
                    .HasComment("Guard Error");

                entity.Property(e => e.Cell3quality)
                    .HasColumnName("cell3quality")
                    .HasComment("Guard Quality (%)");

                entity.Property(e => e.Cell3time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell3time")
                    .HasComment("Guard trigger time");

                entity.Property(e => e.Cell4active)
                    .HasColumnName("cell4active")
                    .HasComment("60' active");

                entity.Property(e => e.Cell4error)
                    .HasColumnName("cell4error")
                    .HasComment("60' Error");

                entity.Property(e => e.Cell4quality)
                    .HasColumnName("cell4quality")
                    .HasComment("60' Quality (%)");

                entity.Property(e => e.Cell4time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell4time")
                    .HasComment("60' trigger time\n");

                entity.Property(e => e.Cell5active)
                    .HasColumnName("cell5active")
                    .HasComment("330' active");

                entity.Property(e => e.Cell5error)
                    .HasColumnName("cell5error")
                    .HasComment("330' Error");

                entity.Property(e => e.Cell5quality)
                    .HasColumnName("cell5quality")
                    .HasComment("330' Quality (%)");

                entity.Property(e => e.Cell5time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell5time")
                    .HasComment("330' Trigger time");

                entity.Property(e => e.Cell6active)
                    .HasColumnName("cell6active")
                    .HasComment("594' Active");

                entity.Property(e => e.Cell6error)
                    .HasColumnName("cell6error")
                    .HasComment("594' Error");

                entity.Property(e => e.Cell6quality)
                    .HasColumnName("cell6quality")
                    .HasComment("594' Quality (%)");

                entity.Property(e => e.Cell6time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell6time")
                    .HasComment("594' Trigger time");

                entity.Property(e => e.Cell7active)
                    .HasColumnName("cell7active")
                    .HasComment("660' Active");

                entity.Property(e => e.Cell7error)
                    .HasColumnName("cell7error")
                    .HasComment("660' Error");

                entity.Property(e => e.Cell7quality)
                    .HasColumnName("cell7quality")
                    .HasComment("660' Quality (%)");

                entity.Property(e => e.Cell7time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell7time")
                    .HasComment("660' Trigger time");

                entity.Property(e => e.Cell8active)
                    .HasColumnName("cell8active")
                    .HasComment("934' Active");

                entity.Property(e => e.Cell8error)
                    .HasColumnName("cell8error")
                    .HasComment("934' Error");

                entity.Property(e => e.Cell8quality)
                    .HasColumnName("cell8quality")
                    .HasComment("934' Quality (%)");

                entity.Property(e => e.Cell8time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell8time")
                    .HasComment("934' Trigger time");

                entity.Property(e => e.Cell9active)
                    .HasColumnName("cell9active")
                    .HasComment("1000' Active");

                entity.Property(e => e.Cell9error)
                    .HasColumnName("cell9error")
                    .HasComment("1000' Error");

                entity.Property(e => e.Cell9quality)
                    .HasColumnName("cell9quality")
                    .HasComment("1000' Quality (%)");

                entity.Property(e => e.Cell9time)
                    .HasPrecision(8, 6)
                    .HasColumnName("cell9time")
                    .HasComment("1000' Trigger time");

                entity.Property(e => e.Delay)
                    .HasPrecision(4, 3)
                    .HasColumnName("delay")
                    .HasComment("1st Amber Delay");

                entity.Property(e => e.Displayon)
                    .HasColumnName("displayon")
                    .HasComment("Scoreboards Enabled");

                entity.Property(e => e.Dsf)
                    .HasColumnName("dsf")
                    .HasComment("Deep Stage Foul");

                entity.Property(e => e.Foul)
                    .HasColumnName("foul")
                    .HasComment("Foul Start");

                entity.Property(e => e.Guardon)
                    .HasColumnName("guardon")
                    .HasComment("Guard Beam Enabled");

                entity.Property(e => e.Index)
                    .HasPrecision(4, 2)
                    .HasColumnName("index")
                    .HasComment("Index/Dial in\n");

                entity.Property(e => e.Mode)
                    .HasMaxLength(2)
                    .HasColumnName("mode")
                    .IsFixedLength(true)
                    .HasComment("Race Mode (TT, Q, E, QE)\n");

                entity.Property(e => e.Nocar)
                    .HasColumnName("nocar")
                    .HasComment("No Car Stage");

                entity.Property(e => e.Racenum)
                    .HasMaxLength(8)
                    .HasColumnName("racenum")
                    .IsFixedLength(true)
                    .HasComment("Race number");

                entity.Property(e => e.Remboxconnected)
                    .HasColumnName("remboxconnected")
                    .HasComment("Remote Start Box Connected");

                entity.Property(e => e.Rtmode)
                    .HasColumnName("rtmode")
                    .HasComment("Reaction Time Mode (0=Off, 1=Positive, 2=Negative)");

                entity.Property(e => e.Rundatetime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("rundatetime")
                    .HasComment("Rune Date/Time");

                entity.Property(e => e.Scoreboards)
                    .HasColumnName("scoreboards")
                    .HasComment("Number of Scoreboards (1 or 2)");

                entity.Property(e => e.Startmode)
                    .HasColumnName("startmode")
                    .HasComment("Start Mode (0=AutoStart, 1=Tower Start, 2=Remote Start, 3=Test)");

                entity.Property(e => e.Superstart)
                    .HasColumnName("superstart")
                    .HasComment("Super Start Enabled");

                entity.Property(e => e.Tracklength)
                    .HasColumnName("tracklength")
                    .HasComment("Track Length (1=1/8 Mile, 2=1000', 3=1/4 Mile)");

                entity.Property(e => e.Tree)
                    .HasColumnName("tree")
                    .HasComment("Tree Type. 0=.5 FULL, 1=.4 PRO, 2=X OVER, 3=.5 PRO, 4=DELAY");

                entity.Property(e => e.Writetime)
                    .HasPrecision(8, 6)
                    .HasColumnName("writetime")
                    .HasComment("Record Write Time");
            });

            modelBuilder.Entity<RnQual>(entity =>
            {
                entity.ToTable("rn_qual");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Et)
                    .HasPrecision(6, 4)
                    .HasColumnName("et");

                entity.Property(e => e.Index)
                    .HasPrecision(4, 2)
                    .HasColumnName("index");

                entity.Property(e => e.Qualrnd).HasColumnName("qualrnd");

                entity.Property(e => e.Racenum)
                    .HasMaxLength(20)
                    .HasColumnName("racenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Reaction)
                    .HasPrecision(6, 4)
                    .HasColumnName("reaction");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(30)
                    .HasColumnName("remarks")
                    .IsFixedLength(true);

                entity.Property(e => e.Runid).HasColumnName("runid");

                entity.Property(e => e.Speed)
                    .HasPrecision(5, 2)
                    .HasColumnName("speed");
            });

            modelBuilder.Entity<RnRacer>(entity =>
            {
                entity.ToTable("rn_racers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(30)
                    .HasColumnName("address1")
                    .IsFixedLength(true);

                entity.Property(e => e.Address2)
                    .HasMaxLength(30)
                    .HasColumnName("address2")
                    .IsFixedLength(true);

                entity.Property(e => e.Allowpoints).HasColumnName("allowpoints");

                entity.Property(e => e.Carname)
                    .HasMaxLength(30)
                    .HasColumnName("carname")
                    .IsFixedLength(true);

                entity.Property(e => e.Cartype)
                    .HasMaxLength(30)
                    .HasColumnName("cartype")
                    .IsFixedLength(true);

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .HasColumnName("city")
                    .IsFixedLength(true);

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .IsFixedLength(true);

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Driver)
                    .HasMaxLength(30)
                    .HasColumnName("driver")
                    .IsFixedLength(true);

                entity.Property(e => e.Engine)
                    .HasMaxLength(30)
                    .HasColumnName("engine")
                    .IsFixedLength(true);

                entity.Property(e => e.Info1)
                    .HasMaxLength(60)
                    .HasColumnName("info1")
                    .IsFixedLength(true);

                entity.Property(e => e.Info2)
                    .HasMaxLength(60)
                    .HasColumnName("info2")
                    .IsFixedLength(true);

                entity.Property(e => e.Info3)
                    .HasMaxLength(60)
                    .HasColumnName("info3")
                    .IsFixedLength(true);

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Racenum)
                    .HasMaxLength(20)
                    .HasColumnName("racenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Registered).HasColumnName("registered");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .HasColumnName("state")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnRunlog>(entity =>
            {
                entity.HasKey(e => new { e.Runid, e.Lane })
                    .HasName("rn_runlog_pkey");

                entity.ToTable("rn_runlog");

                entity.Property(e => e.Runid).HasColumnName("runid");

                entity.Property(e => e.Lane).HasColumnName("lane");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Diff)
                    .HasPrecision(6, 4)
                    .HasColumnName("diff");

                entity.Property(e => e.Et1000)
                    .HasPrecision(6, 4)
                    .HasColumnName("et1000");

                entity.Property(e => e.Et1320)
                    .HasPrecision(6, 4)
                    .HasColumnName("et1320");

                entity.Property(e => e.Et330)
                    .HasPrecision(6, 4)
                    .HasColumnName("et330");

                entity.Property(e => e.Et594)
                    .HasPrecision(6, 4)
                    .HasColumnName("et594");

                entity.Property(e => e.Et60)
                    .HasPrecision(6, 4)
                    .HasColumnName("et60");

                entity.Property(e => e.Et660)
                    .HasPrecision(6, 4)
                    .HasColumnName("et660");

                entity.Property(e => e.Index)
                    .HasPrecision(4, 2)
                    .HasColumnName("index");

                entity.Property(e => e.Mode)
                    .HasMaxLength(3)
                    .HasColumnName("mode")
                    .IsFixedLength(true);

                entity.Property(e => e.Racenum)
                    .HasMaxLength(8)
                    .HasColumnName("racenum")
                    .IsFixedLength(true);

                entity.Property(e => e.Reaction)
                    .HasPrecision(6, 4)
                    .HasColumnName("reaction");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(30)
                    .HasColumnName("remarks")
                    .IsFixedLength(true);

                entity.Property(e => e.Result)
                    .HasMaxLength(4)
                    .HasColumnName("result")
                    .IsFixedLength(true);

                entity.Property(e => e.Speed1000)
                    .HasPrecision(5, 2)
                    .HasColumnName("speed1000");

                entity.Property(e => e.Speed1320)
                    .HasPrecision(5, 2)
                    .HasColumnName("speed1320");

                entity.Property(e => e.Speed660)
                    .HasPrecision(5, 2)
                    .HasColumnName("speed660");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<RnTrackinfo>(entity =>
            {
                entity.HasKey(e => e.Eventname)
                    .HasName("rn_trackinfo_pkey");

                entity.ToTable("rn_trackinfo");

                entity.Property(e => e.Eventname)
                    .HasMaxLength(57)
                    .HasColumnName("eventname")
                    .IsFixedLength(true);

                entity.Property(e => e.Leftlane)
                    .HasMaxLength(42)
                    .HasColumnName("leftlane")
                    .IsFixedLength(true);

                entity.Property(e => e.Rightlane)
                    .HasMaxLength(42)
                    .HasColumnName("rightlane")
                    .IsFixedLength(true);

                entity.Property(e => e.Trackname)
                    .HasMaxLength(57)
                    .HasColumnName("trackname")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RnTransact>(entity =>
            {
                entity.ToTable("rn_transact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(10)
                    .HasColumnName("action")
                    .IsFixedLength(true);

                entity.Property(e => e.Identifier)
                    .HasMaxLength(20)
                    .HasColumnName("identifier")
                    .IsFixedLength(true);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Tablename)
                    .HasMaxLength(20)
                    .HasColumnName("tablename")
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}