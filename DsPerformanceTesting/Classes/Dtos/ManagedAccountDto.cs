using System;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class ManagedAccountDto : IServiceDto<ManagedAccountDto>
    {
        #region Properties

        public int Id { get; set; }

        public string SystemName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasPassword { get; set; }

        public bool DisablePasswordRelease { get; set; }

        public string PasswordManagementProfileName { get; set; }

        public string EffectivePasswordManagementProfileName { get; set; }

        public string AssetPartitionName { get; set; }

        public DateTime? LastPasswordCheckDate { get; set; }

        public DateTime? NextPasswordCheckDate { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        public DateTime? NextPasswordChangeDate { get; set; }

        public DateTime? LastSshKeyChangeDate { get; set; }

        public DateTime? NextSshKeyChangeDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedByUserDisplayName { get; set; }

        public string DistinguishedName { get; set; }

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
            var other = obj as ManagedAccountDto;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Id != other.Id) return false;

            if (!Equals(SystemName, other.SystemName)) return false;

            if (!Equals(Name, other.Name)) return false;

            if (!Equals(Description, other.Description)) return false;

            if (HasPassword != other.HasPassword) return false;

            if (DisablePasswordRelease != other.DisablePasswordRelease) return false;

            if (!Equals(PasswordManagementProfileName, other.PasswordManagementProfileName)) return false;

            if (!Equals(EffectivePasswordManagementProfileName, other.EffectivePasswordManagementProfileName)) return false;

            if (!Equals(AssetPartitionName, other.AssetPartitionName)) return false;

            if ((LastPasswordCheckDate.HasValue && !other.LastPasswordCheckDate.HasValue) || (!LastPasswordCheckDate.HasValue && other.LastPasswordCheckDate.HasValue)) return false;
            if (LastPasswordCheckDate.HasValue && !Equals(LastPasswordCheckDate.Value, other.LastPasswordCheckDate.Value)) return false;

            if ((NextPasswordCheckDate.HasValue && !other.NextPasswordCheckDate.HasValue) || (!NextPasswordCheckDate.HasValue && other.NextPasswordCheckDate.HasValue)) return false;
            if (NextPasswordCheckDate.HasValue && !Equals(NextPasswordCheckDate.Value, other.NextPasswordCheckDate.Value)) return false;

            if ((LastPasswordChangeDate.HasValue && !other.LastPasswordChangeDate.HasValue) || (!LastPasswordChangeDate.HasValue && other.LastPasswordChangeDate.HasValue)) return false;
            if (LastPasswordChangeDate.HasValue && !Equals(LastPasswordChangeDate.Value, other.LastPasswordChangeDate.Value)) return false;

            if ((NextPasswordChangeDate.HasValue && !other.NextPasswordChangeDate.HasValue) || (!NextPasswordChangeDate.HasValue && other.NextPasswordChangeDate.HasValue)) return false;
            if (NextPasswordChangeDate.HasValue && !Equals(NextPasswordChangeDate.Value, other.NextPasswordChangeDate.Value)) return false;

            if ((LastSshKeyChangeDate.HasValue && !other.LastSshKeyChangeDate.HasValue) || (!LastSshKeyChangeDate.HasValue && other.LastSshKeyChangeDate.HasValue)) return false;
            if (LastSshKeyChangeDate.HasValue && !Equals(LastSshKeyChangeDate.Value, other.LastSshKeyChangeDate.Value)) return false;

            if ((NextSshKeyChangeDate.HasValue && !other.NextSshKeyChangeDate.HasValue) || (!NextSshKeyChangeDate.HasValue && other.NextSshKeyChangeDate.HasValue)) return false;
            if (NextSshKeyChangeDate.HasValue && !Equals(NextSshKeyChangeDate.Value, other.NextSshKeyChangeDate.Value)) return false;

            if (CreatedDate != other.CreatedDate) return false;

            if (!Equals(CreatedByUserDisplayName, other.CreatedByUserDisplayName)) return false;

            if (!Equals(DistinguishedName, other.DistinguishedName)) return false;

            
            return true;
        }
// ReSharper restore AssignNullToNotNullAttribute
// ReSharper restore PossibleNullReferenceException
// ReSharper restore PossibleInvalidOperationException
        
        public override int GetHashCode()
        {
            var hash = 16769023;

            hash += 3571 * Id.GetHashCode();

            if (SystemName != null) hash += 3571 * SystemName.GetHashCode();

            if (Name != null) hash += 3571 * Name.GetHashCode();

            if (Description != null) hash += 3571 * Description.GetHashCode();

            hash += 3571 * HasPassword.GetHashCode();

            hash += 3571 * DisablePasswordRelease.GetHashCode();

            if (PasswordManagementProfileName != null) hash += 3571 * PasswordManagementProfileName.GetHashCode();

            if (EffectivePasswordManagementProfileName != null) hash += 3571 * EffectivePasswordManagementProfileName.GetHashCode();

            if (AssetPartitionName != null) hash += 3571 * AssetPartitionName.GetHashCode();

            if (LastPasswordCheckDate != null) hash += 3571 * LastPasswordCheckDate.Value.GetHashCode();

            if (NextPasswordCheckDate != null) hash += 3571 * NextPasswordCheckDate.Value.GetHashCode();

            if (LastPasswordChangeDate != null) hash += 3571 * LastPasswordChangeDate.Value.GetHashCode();

            if (NextPasswordChangeDate != null) hash += 3571 * NextPasswordChangeDate.Value.GetHashCode();

            if (LastSshKeyChangeDate != null) hash += 3571 * LastSshKeyChangeDate.Value.GetHashCode();

            if (NextSshKeyChangeDate != null) hash += 3571 * NextSshKeyChangeDate.Value.GetHashCode();

            hash += 3571 * CreatedDate.GetHashCode();

            if (CreatedByUserDisplayName != null) hash += 3571 * CreatedByUserDisplayName.GetHashCode();

            if (DistinguishedName != null) hash += 3571 * DistinguishedName.GetHashCode();


            return hash;
        }

		public override string ToString()
		{
			return string.Format("ManagedAccountDto{{Key: {0}}}", GetKey());
		}
        
        
        #endregion

    }
}
