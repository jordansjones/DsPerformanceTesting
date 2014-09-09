using System;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class GroupDto : IServiceDto<GroupDto>
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        #endregion

        private IDtoKey _dtoKey;

        public IDtoKey GetKey()
        {
            if (_dtoKey == null)
            {
                _dtoKey = new DtoKey(Id);
            }
            return _dtoKey;
        }


        #region Utility Methods
        
// ReSharper disable PossibleInvalidOperationException
// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute
        public override bool Equals(object obj)
        {
            var other = obj as GroupDto;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Id != other.Id) return false;

            if (!Equals(Name, other.Name)) return false;

            if (!Equals(Description, other.Description)) return false;

            if (CreatedDate != other.CreatedDate) return false;

            
            return true;
        }
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore PossibleNullReferenceException
// ReSharper restore PossibleInvalidOperationException
        
        public override int GetHashCode()
        {
            var hash = 16769023;

            hash += 3571 * Id.GetHashCode();

            if (Name != null) hash += 3571 * Name.GetHashCode();

            if (Description != null) hash += 3571 * Description.GetHashCode();

            hash += 3571 * CreatedDate.GetHashCode();


            return hash;
        }

        public override string ToString()
		{
			return string.Format("GroupDto{{Key: {0}}}", GetKey());
		}
        
        
        #endregion

    }
}
