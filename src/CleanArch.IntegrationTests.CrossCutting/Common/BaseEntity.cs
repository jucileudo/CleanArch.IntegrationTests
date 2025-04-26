using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.IntegrationTests.CrossCutting.Common
{
   
        public abstract class BaseEntity
        {
            public Guid Id { get; protected set; }
            public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
            public DateTime? UpdatedAt { get; protected set; }

            protected BaseEntity()
            {
                Id = Guid.NewGuid();
            }

            public void MarkAsUpdated()
            {
                UpdatedAt = DateTime.UtcNow;
            }

            public override bool Equals(object? obj)
            {
                if (obj is not BaseEntity other)
                    return false;

                if (ReferenceEquals(this, other))
                    return true;

                return Id.Equals(other.Id);
            }

            public static bool operator ==(BaseEntity? a, BaseEntity? b)
            {
                if (a is null && b is null)
                    return true;

                if (a is null || b is null)
                    return false;

                return a.Equals(b);
            }

            public static bool operator !=(BaseEntity? a, BaseEntity? b) => !(a == b);

            public override int GetHashCode()
            {
                return GetType().GetHashCode() * 907 + Id.GetHashCode();
            }

            public override string ToString()
            {
                return $"{GetType().Name} [Id={Id}]";
            }
        }
    }

