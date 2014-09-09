using System;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class UserDto : IServiceDto<UserDto>
    {


        #region Properties

        public int Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string PrimaryAuthenticationProviderName { get; set; }

        public string PrimaryAuthenticationIdentity { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string Comment { get; set; }

        public string SecondaryAuthenticationProviderName { get; set; }

        public string SecondaryAuthenticationIdentity { get; set; }

        public bool Disabled { get; set; }

        public bool Locked { get; set; }

        public bool PasswordNeverExpiresFlag { get; set; }

        public string TimeZoneName { get; set; }

        public string TimeZoneDescription { get; set; }

        public string Base64PhotoData { get; set; }

        public bool IsPartitionOwner { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedByUserDisplayName { get; set; }

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
            var other = obj as UserDto;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Id != other.Id) return false;

            if (!Equals(UserName, other.UserName)) return false;

            if (!Equals(DisplayName, other.DisplayName)) return false;

            if (!Equals(PrimaryAuthenticationProviderName, other.PrimaryAuthenticationProviderName)) return false;

            if (!Equals(PrimaryAuthenticationIdentity, other.PrimaryAuthenticationIdentity)) return false;

            if (!Equals(LastName, other.LastName)) return false;

            if (!Equals(FirstName, other.FirstName)) return false;

            if (!Equals(EmailAddress, other.EmailAddress)) return false;

            if (!Equals(WorkPhone, other.WorkPhone)) return false;

            if (!Equals(MobilePhone, other.MobilePhone)) return false;

            if (!Equals(Comment, other.Comment)) return false;

            if (!Equals(SecondaryAuthenticationProviderName, other.SecondaryAuthenticationProviderName)) return false;

            if (!Equals(SecondaryAuthenticationIdentity, other.SecondaryAuthenticationIdentity)) return false;

            if (Disabled != other.Disabled) return false;

            if (Locked != other.Locked) return false;

            if (PasswordNeverExpiresFlag != other.PasswordNeverExpiresFlag) return false;

            if (!Equals(TimeZoneName, other.TimeZoneName)) return false;

            if (!Equals(TimeZoneDescription, other.TimeZoneDescription)) return false;

            if (!Equals(Base64PhotoData, other.Base64PhotoData)) return false;

            if (IsPartitionOwner != other.IsPartitionOwner) return false;

            if ((LastLoginDate.HasValue && !other.LastLoginDate.HasValue) || (!LastLoginDate.HasValue && other.LastLoginDate.HasValue)) return false;
            if (LastLoginDate.HasValue && !Equals(LastLoginDate.Value, other.LastLoginDate.Value)) return false;

            if (CreatedDate != other.CreatedDate) return false;

            if (!Equals(CreatedByUserDisplayName, other.CreatedByUserDisplayName)) return false;

            
            return true;
        }
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore PossibleNullReferenceException
// ReSharper restore PossibleInvalidOperationException
        
        public override int GetHashCode()
        {
            var hash = 16769023;

            hash += 3571 * Id.GetHashCode();

            if (UserName != null) hash += 3571 * UserName.GetHashCode();

            if (DisplayName != null) hash += 3571 * DisplayName.GetHashCode();

            if (PrimaryAuthenticationProviderName != null) hash += 3571 * PrimaryAuthenticationProviderName.GetHashCode();

            if (PrimaryAuthenticationIdentity != null) hash += 3571 * PrimaryAuthenticationIdentity.GetHashCode();

            if (LastName != null) hash += 3571 * LastName.GetHashCode();

            if (FirstName != null) hash += 3571 * FirstName.GetHashCode();

            if (EmailAddress != null) hash += 3571 * EmailAddress.GetHashCode();

            if (WorkPhone != null) hash += 3571 * WorkPhone.GetHashCode();

            if (MobilePhone != null) hash += 3571 * MobilePhone.GetHashCode();

            if (Comment != null) hash += 3571 * Comment.GetHashCode();

            if (SecondaryAuthenticationProviderName != null) hash += 3571 * SecondaryAuthenticationProviderName.GetHashCode();

            if (SecondaryAuthenticationIdentity != null) hash += 3571 * SecondaryAuthenticationIdentity.GetHashCode();

            hash += 3571 * Disabled.GetHashCode();

            hash += 3571 * Locked.GetHashCode();

            hash += 3571 * PasswordNeverExpiresFlag.GetHashCode();

            if (TimeZoneName != null) hash += 3571 * TimeZoneName.GetHashCode();

            if (TimeZoneDescription != null) hash += 3571 * TimeZoneDescription.GetHashCode();

            if (Base64PhotoData != null) hash += 3571 * Base64PhotoData.GetHashCode();

            hash += 3571 * IsPartitionOwner.GetHashCode();

            if (LastLoginDate != null) hash += 3571 * LastLoginDate.Value.GetHashCode();

            hash += 3571 * CreatedDate.GetHashCode();

            if (CreatedByUserDisplayName != null) hash += 3571 * CreatedByUserDisplayName.GetHashCode();


            return hash;
        }

		public override string ToString()
		{
			return string.Format("UserDto{{Key: {0}}}", GetKey());
		}
        
        
        #endregion

    }
}