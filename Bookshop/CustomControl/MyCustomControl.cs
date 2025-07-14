using System.Windows;
using System.Windows.Controls;

namespace CustomControl;

 // Наследуем от Button – для демонстрации можно расширить стандартную кнопку.
 public class MyCustomControl : Button
 {
     static MyCustomControl()
     {
         // DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl),
         //     new FrameworkPropertyMetadata(typeof(MyCustomControl)));
     }

     #region DependencyProperty с валидацией и коррекцией

     // Булевое свойство – для примера.
     public static readonly DependencyProperty CustomFlagProperty =
         DependencyProperty.Register(
             nameof(CustomFlag),
             typeof(bool),
             typeof(MyCustomControl),
             new FrameworkPropertyMetadata(true,
                 FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                 null,
                 CoerceCustomFlag),
             ValidateCustomFlag);

     public bool CustomFlag
     {
         get => (bool)GetValue(CustomFlagProperty);
         set => SetValue(CustomFlagProperty, value);
     }

     private static bool ValidateCustomFlag(object value)
     {
         return value is bool;
     }

     private static object CoerceCustomFlag(DependencyObject d, object baseValue)
     {
         // Для демонстрации можно оставить значение без коррекции.
         return baseValue;
     }

     // Строковое свойство Description с проверкой и коррекцией.
     public static readonly DependencyProperty DescriptionProperty =
         DependencyProperty.Register(
             nameof(Description),
             typeof(string),
             typeof(MyCustomControl),
             new FrameworkPropertyMetadata("Default Description",
                 FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                 null,
                 CoerceDescription),
             ValidateDescription);

     public string Description
     {
         get => (string)GetValue(DescriptionProperty);
         set => SetValue(DescriptionProperty, value);
     }

     private static bool ValidateDescription(object value)
     {
         // Не допускаем значение null.
         return value is string;
     }

     private static object CoerceDescription(DependencyObject d, object baseValue)
     {
         var str = baseValue as string;
         return string.IsNullOrEmpty(str) ? "Default Description" : str;
     }

     #endregion DependencyProperty

     #region Routed Event

     // Определяем событие, которое будет происходить при нажатии кнопки.
     // Используем стратегию Bubbling, чтобы событие поднималось вверх по визуальному дереву.
     public static readonly RoutedEvent ButtonClickedEvent =
         EventManager.RegisterRoutedEvent("ButtonClicked", RoutingStrategy.Bubble,
             typeof(RoutedEventHandler), typeof(MyCustomControl));

     public event RoutedEventHandler ButtonClicked
     {
         add => AddHandler(ButtonClickedEvent, value);
         remove => RemoveHandler(ButtonClickedEvent, value);
     }

     // Переопределяем OnClick, чтобы вызвать наше событие
     protected override void OnClick()
     {
         base.OnClick();
         RaiseEvent(new RoutedEventArgs(ButtonClickedEvent, this));
     }

     #endregion Routed Event
 }