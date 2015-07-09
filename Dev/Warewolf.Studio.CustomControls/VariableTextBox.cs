﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Warewolf.Studio.CustomControls
{
    public class VariableTextBox : TextBox
    {
        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(VariableTextBox));

        public static DependencyProperty LabelTextColorProperty =
            DependencyProperty.Register(
                "LabelTextColor",
                typeof(Brush),
                typeof(VariableTextBox));

        public static DependencyProperty AddNoteCommandProperty =
            DependencyProperty.Register(
                "AddNoteCommand",
                typeof(ICommand),
                typeof(VariableTextBox));

        public static DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                "DeleteCommand",
                typeof(ICommand),
                typeof(VariableTextBox));

        private static DependencyPropertyKey HasTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "HasText",
                typeof(bool),
                typeof(VariableTextBox),
                new PropertyMetadata());
        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        static VariableTextBox() {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(VariableTextBox),
                new FrameworkPropertyMetadata(typeof(VariableTextBox)));
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            HasText = Text.Length != 0;
        }

        protected override void OnTextChanged(TextChangedEventArgs e) {
            base.OnTextChanged(e);
            
            HasText = Text.Length != 0;
            if (!HasText)
            {
                Focus();
            }
        }

        public string LabelText {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public Brush LabelTextColor {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public ICommand AddNoteCommand
        {
            get
            {
                return (ICommand)GetValue(AddNoteCommandProperty);
            }
            set
            {
                SetValue(AddNoteCommandProperty, value);
            }
        }

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set
            {
                SetValue(DeleteCommandProperty, value);
            }
        }

        public bool HasText {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }
    }
}
