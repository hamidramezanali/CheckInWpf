using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.ViewModel
{
    public class ErrorViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>>  _propertErrors = new Dictionary<string, List<string>>();
        public bool HasErrors => _propertErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
          return _propertErrors.GetValueOrDefault(propertyName,null);
        }
        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertErrors.ContainsKey(propertyName))
            {
                _propertErrors.Add(propertyName, new List<string>());
            }
            _propertErrors[propertyName].Add(errorMessage);
            OnErrorCHange(propertyName);
        }
        public void ClearError(string propertyName, string errorMessage)
        {

        }
        private void OnErrorCHange(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
