using System;

#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Raw incremental times and diagnostic data for each run
    /// Derived from T_MASTER.RCE
    /// </summary>
    public partial class RnMasterlist
    {
        /// <summary>
        /// Run Number
        /// </summary>
        public int Runindex { get; set; }

        /// <summary>
        /// FALSE: left, TRUE: right
        /// </summary>
        public bool Lane { get; set; }

        /// <summary>
        /// Date/Time of the run
        /// </summary>
        public DateTime? Rundatetime { get; set; }

        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Mode in run was in
        /// Qualifying, Eliminations, Time trials
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Racenumber
        /// </summary>
        public string Racenum { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// Pre-Stage Remake Time
        /// </summary>
        public decimal? Cell1time { get; set; }

        /// <summary>
        /// Stage Remake Time
        /// </summary>
        public decimal? Cell2time { get; set; }

        /// <summary>
        /// Guard Trigger Time
        /// </summary>
        public decimal? Cell3time { get; set; }

        /// <summary>
        /// 60' Trigger Time
        /// </summary>
        public decimal? Cell4time { get; set; }

        /// <summary>
        /// 330' Trigger Time
        /// </summary>
        public decimal? Cell5time { get; set; }

        /// <summary>
        /// 594' Trigger Time
        /// </summary>
        public decimal? Cell6time { get; set; }

        /// <summary>
        /// 660' Trigger Time
        /// </summary>
        public decimal? Cell7time { get; set; }

        /// <summary>
        /// 934' Trigger Time
        /// </summary>
        public decimal? Cell8time { get; set; }

        /// <summary>
        /// 1000' Trigger Time
        /// </summary>
        public decimal? Cell9time { get; set; }

        /// <summary>
        /// 1254' Trigger Time
        /// </summary>
        public decimal? Cell10time { get; set; }

        /// <summary>
        /// 1320' Trigger Time
        /// </summary>
        public decimal? Cell11time { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Cell12time { get; set; }

        /// <summary>
        /// Pre-Stage Active
        /// </summary>
        public bool? Cell1active { get; set; }

        /// <summary>
        /// Stage Active
        /// </summary>
        public bool? Cell2active { get; set; }

        /// <summary>
        /// Guard Active
        /// </summary>
        public bool? Cell3active { get; set; }

        /// <summary>
        /// 60' Active
        /// </summary>
        public bool? Cell4active { get; set; }

        /// <summary>
        /// 330' Active
        /// </summary>
        public bool? Cell5active { get; set; }

        /// <summary>
        /// 594' Active
        /// </summary>
        public bool? Cell6active { get; set; }

        /// <summary>
        /// 660' Active
        /// </summary>
        public bool? Cell7active { get; set; }

        /// <summary>
        /// 934' Active
        /// </summary>
        public bool? Cell8active { get; set; }

        /// <summary>
        /// 1000' Active
        /// </summary>
        public bool? Cell9active { get; set; }

        /// <summary>
        /// 1254' Active
        /// </summary>
        public bool? Cell10active { get; set; }

        /// <summary>
        /// 1320' Active
        /// </summary>
        public bool? Cell11active { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell12active { get; set; }

        /// <summary>
        /// Pre-Stage Signal Quality
        /// </summary>
        public float? Cell1quality { get; set; }

        /// <summary>
        /// Stage Signal Quality
        /// </summary>
        public float? Cell2quality { get; set; }

        /// <summary>
        /// Guard Signal Quality
        /// </summary>
        public float? Cell3quality { get; set; }

        /// <summary>
        /// 60' Signal Quality
        /// </summary>
        public float? Cell4quality { get; set; }

        /// <summary>
        /// 330' Signal Quality
        /// </summary>
        public float? Cell5quality { get; set; }

        /// <summary>
        /// 594' Signal Quality
        /// </summary>
        public float? Cell6quality { get; set; }

        /// <summary>
        /// 660' Signal Quality
        /// </summary>
        public float? Cell7quality { get; set; }

        /// <summary>
        /// 934' Signal Quality
        /// </summary>
        public float? Cell8quality { get; set; }

        /// <summary>
        /// 1000' Signal Quality
        /// </summary>
        public float? Cell9quality { get; set; }

        /// <summary>
        /// 1254' Signal Quality
        /// </summary>
        public float? Cell10quality { get; set; }

        /// <summary>
        /// 1320' Signal Quality
        /// </summary>
        public float? Cell11quality { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float? Cell12quality { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell1error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell2error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell3error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell4error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell5error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell6error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell7error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell8error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell9error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell10error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell11error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Cell12error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Foul { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Dsf { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Aborted { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Nocar { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Amber1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Amber2 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Amber3 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Delay { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Tree { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Startmode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Remboxconnected { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Autostartstagestart { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Autostarttimeout { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Guardon { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Superstart { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Rtmode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Bkoutmode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Tracklength { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? Displayon { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Scoreboards { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Writetime { get; set; }
    }
}