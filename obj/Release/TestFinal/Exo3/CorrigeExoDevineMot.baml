   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfApplication1.TestFinal.Exo3WpfApplication1.TestFinal.Exo3  8    2WpfApplication1.TestFinal.Exo3.CorrigeExoDevineMot   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:WpfApplication1.TestFinal.Exo3     $	��451��$
��1100��  N� Title$  ExoDevineMot�� � 	Resources    
ZoomImage1 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  
ZoomImage2��%8  &	        &	 �    �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 
ImageProp1��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$ 1.243Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 
ImageProp1��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$ 0Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 
ImageProp1��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$ 1.223Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
ImageProp1��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$ 0.334Q��� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 
ImageProp2��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$ 1.212Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 
ImageProp2��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$ 0Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 
ImageProp2��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$ 1.173Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
ImageProp2��.\�  $ 0��$ 0Q�  $ 0:0:0.2��$ 0.334Q� � Triggers :�  :� RoutedEvent$ UIElement.MouseEnter�� :� 
SourceName$ 
ImageProp1��.[��� -   	 ��Name$ 	 ZoomImage1_BeginStoryboard��#��[  :� $ UIElement.MouseLeave��$ 
ImageProp1��.[��� 
 �� BeginStoryboardName$ 
 ZoomImage1_BeginStoryboard��:� $ UIElement.MouseEnter��$ 
ImageProp2��.[��� -   $ 	 ZoomImage2_BeginStoryboard��#��[ :� $ UIElement.MouseLeave��$ 
ImageProp2��.[��� $ 
 ZoomImage2_BeginStoryboard��.��� -    �Name$ DevineMotGrid�����	#FF094053 � RowDefinitions �� $	��10* ��� $	��75* ��� $
��195* ��� $	��60* ��� $
��111* � � ColumnDefinitions �� $��7* ��� $	��40* ��� $��8* �.+��� -    ��Name$ ScoreTB��  StyleTBlkVF#���  $��2��$��2��$
��Auto��$��-69,-14,10,97q�$��Stretch=�$
��Auto��$��Stretch=��� -    ��Name$ 
ImageProp1��$��1��$��2�� J� RenderTransformOrigin$ 0.5,0.5&�$��Right=�$��0,0,100.646,12.301q�$��246.354��z�V� .~��� �� �� T� �� -   $ 
ImageProp2��$��1��$��2��$ 0.5,0.5&�$
��Left=�$��91.301,0,0,12.301q�$��242.699��z�V� .~��� �� �� T� �� -    ��Name$ Previous��$#��الإجابة السابقة��  
StyleBtnVF#���  
��� ���$��0,46.005,0,2.995q�$��1��$��4��$	��191��$
��Auto��$��Right=��� -   $
 Next��$#��الإجابة التالية��#���  
��� ���$��36,45.005,0,2.995q�$��4��$	��186��$
��Auto��$��1��$
��Left=��� -	    ��Name$ L4��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��30(����	#FF1ABC9C$��Center=�
�������$ 0.554,0.516&�$��4q�$��1��$$��336.068,22.015,389.932,-26.015q�$��3���� -
   $ L1��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��30(����	#FF1ABC9C$��Center=�
�������$��4q�$��1��$��0,22.015,172.932,-26.015q�$��3��$��Right=�$��74���� -   $ L5��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��74��$��30(����	#FF1ABC9C$��Center=�
�������$ 0.554,0.516&�$��4q�$��1��$
��Left=�$��262.068,22.015,0,-26.015q�$��3���� -   $ L2��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��74��$��30(����	#FF1ABC9C$��Center=�
�������$ 0.554,0.516&�$��4q�$��1��$��Right=�$��0,22.015,246.932,-26.015q�$��3���� -   $ L6��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��30(����	#FF1ABC9C$��Center=�
�������$ 0.554,0.516&�$��4q�$��188.068,22.015,0,-26.015q�$��3��$��1��$
��Left=�$��74���� -   $ L3��$2��,/WpfApplication1;component/Fonts/#El Messiri)����	#FF08AE47$��30(����	#FF1ABC9C$��Center=�
�������$��4q�$��1��$��0,22.015,315.932,-26.015q�$��3��$��Right=�$��74���� -    ��Name$ richTextBox��  
StyleRTBVF#���  ���	#FFF1C20F���	#FF455799$ 0.5,0.5&�$��60��$	��Top=�$��1��$��36,6,4,0q�$��2��. �/� .T�J�  �� TextAlignment$ Center=�.*�.*��� -    ��Name$ Question��