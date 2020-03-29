using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Web.ViewModels.Components
{
    public class LinkedNavigation
    {
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3)]
        public string Text { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 2)]
        public string Page { get; set; }

        public bool IsActive { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
