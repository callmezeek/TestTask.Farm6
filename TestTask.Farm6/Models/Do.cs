namespace TestTask.Farm6.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Do
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}