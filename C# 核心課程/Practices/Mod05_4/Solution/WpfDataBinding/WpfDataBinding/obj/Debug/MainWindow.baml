   M S B A M L   `   `   `  ����I  EWpfDataBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfDataBindingWpfDataBinding  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       WpfDataBinding.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfDataBinding     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$  
MainWindow��5	   	   $��395.974��6   $	��525��6-    � 	Resources 5
         AppName  playersViewSource  DataTemplate1 � RowDefinitions ��Name  
HeaderText �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint	 � Color
 � Offset��%�  &	        &	 '     &	 :     &	     ��5      參賽者清單��6,   �� 5      6   �� 5      .R�5      � $	��171��6_   ��6<   �� *PreferColor+ 5   
   �� 5      $	��43* �6   �� 5      $	��45* �6   .+�5   
   �� $ 	textBlock��6   $
��Left=�6'   $��	10,10,0,0q�6B   $
��Wrap=�6U   $	��Top=�6}   $	��151��6�   ��6i   �� *ID+6�   �� 5   
   $ 
textBlock1��6   $
��Left=�6(   $��	10,10,0,0q�6C   $��1��6V   $
��Wrap=�6c   $	��Top=�6�   $	��151��6�   ��6w   �� *Name+6�   5   	   5      �� 5      " ��6   .�5      ��  � �� 5   
   �� 5      $ 0.5,1&�6    $ 0.5,0&�61   .��5      � $	 	#FF0035FF��6   $
 0Q�6-   � 5      $	 	#FF6D7EE3��6   $
 1Q�6-   5      5   	   �� 5        � ��$ 48(�6#   �� 5!       �@��TextAlignment$ Center=�6(   5"      5#      .��5$      � -   5         �Name$ 
LayoutRoot��5$   	    � DataContext# [ 6   ��6N   �� *SelectedItem+ �� ElementName$ lstPreferColor�� � ColumnDefinitions 5%      �� 5&      $
��245* �6   �� 5'      $
��272* �6   .+�5)      �� -   5         ��Name$ txtID��5)      $��1��6   $
��Left=�6-   $��23��6H   $��
95,115,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��120��6�   ��6�   �� *ID+�� 5*      $
��Name��6   $��1��6   $
��Left=�6+   $��34��6F   $��
10,150,0,0q�6R   $	��Top=�6f   $��45��6~   �� 5+      -   5        $ txtName��5+      $��1��6   $
��Left=�6/   $��23��6J   $��
95,154,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��120��6�   ��6�   �� *Name+�� 5,      $��Prefer Color��6   $��1��6#   $
��Left=�63   $��25��6N   $��
10,193,0,0q�6Z   $	��Top=�6n   $��75��6�   �� 5-      -   5         ��Name$ lstPreferColor��5-      $��1��6&   $
��Left=�66   $	��107��6Q   $��
95,195,0,0q�6^   $	��Top=�6r   $	��120��6�    �� SelectedItem 6�   �� *PreferColor+.@�5.      ��Red��6   ��5/      
Yellow��6   ��50      	White��6   51      �� 52      -   5        $ playersListBox��52      $��38,99,43,19q�6>    �� SelectedValuePath$ ID��6S   #���  6j   ��6&   �� 6j   �� 53      -   5        $ 	textBlock��53      $
��Left=�6#   $��	38,10,0,0q�6>   $
��Wrap=�6Q   #���   6e   $	��Top=�6�   $	��422��6�   $��2��6�   $��65��6�   #���  6�   55      56      