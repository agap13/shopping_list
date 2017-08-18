using System;
using Xamarin.Forms;

namespace Shopping.Core.Behaviors
{
    public class DoubleValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(DoubleValidationBehavior), false);

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }


        protected override void OnDetachingFrom(Entry entry)
        {

            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }


        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            IsValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = IsValid ? Color.Black : Color.Red;
        }
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }

        }
    }
}
