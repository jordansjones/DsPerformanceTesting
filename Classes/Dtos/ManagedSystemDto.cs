using System;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class ManagedSystemDto : IServiceDto<ManagedSystemDto>
    {

        #region Properties
    
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string NetworkAddress { get; set; }

        public string DomainName { get; set; }

        public string NetBiosName { get; set; }

        public string SshHostKeyFingerprint { get; set; }

        public string PasswordManagementProfileName { get; set; }

        public string EffectivePasswordManagementProfileName { get; set; }

        public string AssetPartitionName { get; set; }

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
            var other = obj as ManagedSystemDto;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Id != other.Id) return false;

            if (!Equals(Name, other.Name)) return false;

            if (!Equals(Description, other.Description)) return false;

            if (!Equals(NetworkAddress, other.NetworkAddress)) return false;

            if (!Equals(DomainName, other.DomainName)) return false;

            if (!Equals(NetBiosName, other.NetBiosName)) return false;

            if (!Equals(SshHostKeyFingerprint, other.SshHostKeyFingerprint)) return false;

            if (!Equals(PasswordManagementProfileName, other.PasswordManagementProfileName)) return false;

            if (!Equals(EffectivePasswordManagementProfileName, other.EffectivePasswordManagementProfileName)) return false;

            if (!Equals(AssetPartitionName, other.AssetPartitionName)) return false;

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

            if (Name != null) hash += 3571 * Name.GetHashCode();

            if (Description != null) hash += 3571 * Description.GetHashCode();

            if (NetworkAddress != null) hash += 3571 * NetworkAddress.GetHashCode();

            if (DomainName != null) hash += 3571 * DomainName.GetHashCode();

            if (NetBiosName != null) hash += 3571 * NetBiosName.GetHashCode();

            if (SshHostKeyFingerprint != null) hash += 3571 * SshHostKeyFingerprint.GetHashCode();

            if (PasswordManagementProfileName != null) hash += 3571 * PasswordManagementProfileName.GetHashCode();

            if (EffectivePasswordManagementProfileName != null) hash += 3571 * EffectivePasswordManagementProfileName.GetHashCode();

            if (AssetPartitionName != null) hash += 3571 * AssetPartitionName.GetHashCode();

            hash += 3571 * CreatedDate.GetHashCode();

            if (CreatedByUserDisplayName != null) hash += 3571 * CreatedByUserDisplayName.GetHashCode();


            return hash;
        }

		public override string ToString()
		{
			return string.Format("ManagedSystemDto{{Key: {0}}}", GetKey());
		}
        
        
        #endregion

    }
}