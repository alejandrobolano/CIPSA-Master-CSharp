using System;
using VideoClub.Common.Model.Exceptions;
using VideoClub.Common.Model.Utils;

namespace VideoClub.Common.Model.Models
{
    public class Movie : Product
    {
        #region Private properties

        private int _buyYear;
        private int _productionYear;
        private readonly int _yearToday = DateTime.Today.Year;

        #endregion

        #region Public properties

        public TimeSpan Duration { get; set; }

        public int ProductionYear
        {
            get => _productionYear;
            set
            {
                if (value > _yearToday)
                {
                    throw new InvalidYearException(value);
                }

                if (value > BuyYear)
                {
                    throw new InvalidCompareYearException();
                }
                _productionYear = value;
            }
        }

        public int BuyYear
        {
            get => _buyYear;
            set
            {
                if (value > _yearToday)
                {
                    throw new InvalidYearException(value);
                }

                if (ProductionYear > value)
                {
                    throw new InvalidCompareYearException();
                }
                _buyYear = value;
            }
        }

        #endregion
        
        public Movie()
        {
            var random = new Random();
            Id = Helper.GetCodeNumber(Helper.Movie, 6, random);
        }

    }
}
