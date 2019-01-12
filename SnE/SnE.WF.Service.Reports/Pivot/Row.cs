using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Models.dp_mdata_dist.Publications
{
    public class Row
    {

        private string Name;

        private int PrimaryInd;
        private int PrimaryPub;

        private int SecondaryInd;
        private int SecondaryPub;

        private int CombinedInd;
        private int CombinedPub;

        private int IntermediatePub;
        private int IntermediateInd;

        private int? Term;

        private int totalSchoolPerDistrict = 0;


        //public Row(ft_SchoolsPrDistrictPrSector i)
        //{
        //    if (i != null)
        //    {
        //        this.Name = string.IsNullOrEmpty(this.Name) ? i.Name : this.Name;
        //        this.Term = this.Term ?? i.Term;
        //    }

        //}

        public string districtName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public int intPrimaryInd
        {
            get
            {
                return PrimaryInd;
            }
            set
            {
                PrimaryInd = value;
            }
        }
        public int intPrimaryPub
        {
            get
            {
                return PrimaryPub;
            }
            set
            {
                PrimaryPub = value;
            }
        }

        public int intSecondaryInd
        {
            get
            {
                return SecondaryInd;
            }
            set
            {
                SecondaryInd = value;
            }
        }
        public int intSecondaryPub
        {
            get
            {
                return SecondaryPub;
            }
            set
            {
                SecondaryPub = value;
            }
        }

        public int intCombinedInd
        {
            get
            {
                return CombinedInd;
            }
            set
            {
                CombinedInd = value;
            }
        }


        public int intCombinedPub
        {
            get
            {
                return CombinedPub;
            }
            set
            {
                CombinedPub = value;
            }

        }

        public int intIntermediatePub
        {
            get
            {
                return IntermediatePub;
            }
            set
            {
                IntermediatePub = value;
            }

        }


        public int intIntermediateInd
        {
            get
            {
                return IntermediateInd;
            }
            set
            {
                IntermediateInd = value;
            }

        }


        public int Total { 
            get { return totalSchoolPerDistrict;}
            set {
                totalSchoolPerDistrict += value;                
            }
        }


        public int? intTerm
        {
            get
            {
                return Term;
            }
            set
            {
                Term = value;
            }
        }
    }
}