using System.ComponentModel.DataAnnotations;

namespace JKCore.Test.Fake.Models
{
    internal class ModelWithAnnotations
    {
        public ModelWithAnnotations()
        {
        }
        
        [Required]
        public string RequiredString { get; set; }
    }
}