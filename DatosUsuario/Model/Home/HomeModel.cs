using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace DatosUsuario.Model.Home
{
    public class HomeModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("date_add")]
        public string DateAdd { get; set; }

        [JsonProperty("date_upd")]
        public string DateUpd { get; set; }

        [JsonProperty("password_md5")]
        public string PasswordMd5 { get; set; }
    }
}
