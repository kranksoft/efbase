using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kranksoft.EF.Base
{
    /// <summary>
    /// Entity Framework base class with generic type for the Id column.
    /// </summary>
    public interface IModifiableEntity
    {
        string Name { get; set; }
    }

    public interface IEntity : IModifiableEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        byte[] Version { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }

    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get => Id;
            set => Id = (T)value;
        }

        [MaxLength(24)]
        public string Name { get; set; }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate
        {
            get => createdDate ?? DateTime.UtcNow;
            set => createdDate = value;
        }

        [DataType(DataType.DateTime)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }

        [Editable(false)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [Editable(false)]
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }

        [Timestamp]
        [Editable(false)]
        [ScaffoldColumn(false)]
        public byte[] Version { get; set; }
    }
}

