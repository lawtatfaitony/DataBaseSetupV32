﻿using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class Position
    {
        public string PositionId { get; set; }
        /// <summary>
        /// default value = 0 (IsParentsNode)
        /// </summary>
        public string ParentsNodeId { get; set; }
        public string IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string PositionTitle { get; set; }
        public string EnPositionTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MainComId { get; set; }
    }
}
