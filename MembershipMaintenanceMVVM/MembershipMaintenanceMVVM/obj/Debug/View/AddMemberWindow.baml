   M S B A M L   `   `   `  ����T  PMembershipMaintenanceMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MembershipMaintenanceMVVM.ViewMembershipMaintenanceMVVM.View  5   	   4    .MembershipMaintenanceMVVM.View.AddMemberWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:MembershipMaintenanceMVVM.View     5   	     � Title$  AddMemberWindow��5   	   $��219.939��6!   $��311.043��62    � DataContext 5	   	   �� *AddMemberViewModel+   Locator �� Source# [  .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��27* �6   �� 5      $	��74* �6   .+�5   
   �� -   5         ��Name$ 	fNameText��5      $��First Name:��6#   $
��Left=�69   $��	23,31,0,0q�6T   $	��Top=�6g   $��2��6   �� 5   
   -   5        $ 	lNameText��5      $��
Last Name:��6#   $
��Left=�68   $��	24,62,0,0q�6S   $	��Top=�6f   $��2��6~   �� 5   
   -   5        $ 	emailText��5      $��Email:��6#   $
��Left=�64   $��	24,93,0,0q�6O   $	��Top=�6b   �� 5   
   -   5         ��Name$ fNameBox��5      $
��Left=�6$   $��23��6?   $��	28,31,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6�   $	��147��6�   $��1��6�   ��6r   �� *	FNameText+6�   �� 5   
   -   5        $ lNameBox��5      $
��Left=�6$   $��23��6?   $��	28,65,0,0q�6K   $
 Wrap=�6^   $	��Top=�6�   $	��147��6�   $��1��6�   ��6r   �� *	LNameText+6�   �� 5   
   -   5        $ emailBox��5      $
��Left=�6$   $��23��6?   $��	28,96,0,0q�6K   $
 Wrap=�6^   $	��Top=�6�   $	��147��6�   $��1��6�   ��6r   �� *	emailText+6�   �� 5   
   -   5         ��Name$ 
saveButtom��5      $
��Save��6%   $
��Left=�64   $��	0,147,0,0q�6O   $	��Top=�6b   $��75��6z   $��1��6�   ��6�   �� *SaveCommand+�� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $��1��68   $
��Left=�6H   $��100,147,0,0q�6c   $	��Top=�6x   $��75��6�   ��6�   �� *CancelCommand+ �� Mode$ OneWay=���6�   �� 	 �� ElementName$	 AddMemberWindow��5      5      