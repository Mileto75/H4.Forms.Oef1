using Microsoft.AspNetCore.Mvc;

namespace H4.Forms.Oef1.Models
{
    public class CheckboxModel
    {
        public bool IsSelected { get; set; }

        [HiddenInput]
        public int Value { get; set; }
        [HiddenInput]
        public string Text { get; set; }
    }
}
