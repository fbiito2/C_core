   M S B A M L   `   `   `  ����B  >Mod03_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Mod03_1Mod03_1  5   	       Mod03_1.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Mod03_1     5   	   -   5          � Title$  Window1��5   	   $��233.898��6   $��383.9��6*    � 	Resources 5	         storeViewSource��%   &	        �� 5
      6   5      .��5      �  � DataContext# [  6	   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ storeDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��11,12,10,10q�6y      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6a   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   
   -   5        
cityColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 city��5   J   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 SizeToHeader 6X   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *city+6X     5   
   -   5        stateColumn��$ state��5   L   $	 SizeToHeader 6[   
 62   �� *state+6[     5   
   -   5        stor_addressColumn��$ stor address��5   Z   $	 SizeToHeader 6p   
 69   �� *stor_address+6p     5   
   -   5        stor_idColumn��$ stor id��5   P   $	 SizeToHeader 6a   
 64   �� *	stor_id+6a     5   
   -   5        stor_nameColumn��$ 	stor name��5   T   $	 SizeToHeader 6g   
 66   �� *	stor_name+6g     5   
   -   5        	zipColumn��$	 zip��5   H   $	 SizeToHeader 6U   
 60   �� *zip+6U   5      5      5      