   M S B A M L   `   `   `  ����R  NCustomerMaintenanceMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CustomerMaintenanceMVVM.ViewCustomerMaintenanceMVVM.View  5   	   2    ,CustomerMaintenanceMVVM.View.AddUpdateWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:CustomerMaintenanceMVVM.View     5   	   $��213.607��5   *   $��444.304��6;     � Title  6	   ��  �� Path$ 	TitleText� � DataContext 5	   	   �� *	AddUpdate+   Locator �� Source# [  .��5
      � .+�5   
   �� -   5         ��Name$ 	NameLabel��5      $��Name:��6#   $
��Left=�63   $��	29,26,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ AddressLabel��5      $��Address:��6&   $
��Left=�69   $��	29,53,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ 	CityLabel��5      $��City:��6#   $
��Left=�63   $��	29,79,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ 
StateLabel��5      $��State:��6$   $
��Left=�65   $��
29,105,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ ZipLabel��5      $��	Zip code:��6"   $
��Left=�66   $��211,105,0,0q�6Q   $	��Top=�6f    J� RenderTransformOrigin$ 0.548,1.408&�6~   �� 5   
   -   5         ��Name$ NameBox��5      $
��Left=�6=   $��23��6X   $��
89,26,-9,0q�6d    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��305��6�   ��6#   �� *
NameText+6�   �� 5   
   -   5        $ 
AddressBox��5      $
��Left=�6@   $��23��6[   $��
89,54,-9,0q�6g   $
 Wrap=�6{   $	��Top=�6�   $	��305��6�   ��6&   �� *
AddrText+6�   �� 5   
   -   5        $ CityBox��5      $
��Left=�6=   $��23��6X   $��
89,82,-9,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��305��6�   ��6#   �� *
CityText+6�   �� 5   
   -	   5        $ ZipBox��5      $
��Left=�6;   $��23��6V   $��274,110,-9,0q�6b   $
 Wrap=�6x   $	��Top=�6�   $	��120��6�   ��6"   �� *	ZipText+6�   �� 5   
   -
   5         ��Name$ 
SaveButton��5      $
��Save��6%   $
��Left=�6M   $��
29,143,0,0q�6h   $	��Top=�6|   $��75��6�   ��64   �� *Save+6�   �� 5   
   -   5        $ CancelButton��5      $��Cancel��6'   $
��Left=�6S   $��319,143,0,0q�6n   $	��Top=�6�   $��75��6�   ��68   �� *Cancel+6�   �� 5   
   -   5        	 ��Name$	 StateComboBox��5      $
��Left=�6*   $��
89,111,0,0q�6E   $	��Top=�6Y   $	��120��6q   
 �� DisplayMemberPath$
 	StateName��5       �� SelectedValuePath$ 	StateCode��5      ��5      �� *
StateCombo+ �� SelectedValue 5      �� *selectedState+ �� Mode$ TwoWay=�5      5      