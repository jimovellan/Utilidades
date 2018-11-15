using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jim.Utils.Entities.Base
{
    public class EntityWrapper<T> : INotifyPropertyChanged
    {

        #region Private fields
        private T _model;
        
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor's
        public EntityWrapper(T model)
        {
            _model = Model;
        }
        #endregion

        
        public void SetProperty<TProperty>(TProperty value,[CallerMemberName] string PropertyName = "")
        {
            typeof(T).GetProperty(PropertyName).SetValue(_model, value);
        }

        public TProperty GetProperty<TProperty>([CallerMemberName] string PropertyName = "")
        {
            return (TProperty)typeof(T).GetProperty(PropertyName).GetValue(_model);
        }
        
        public void SetValue<TValue>(TValue value,[CallerMemberName] string PropertyName="")
        {
            
            if(!EqualityComparer<TValue>.Default.Equals(GetProperty<TValue>(PropertyName),value))
            {
                SetProperty(value);
                PropertyChanged.Invoke(_model, new PropertyChangedEventArgs(PropertyName));
            }
            
            
        }
    }
}
