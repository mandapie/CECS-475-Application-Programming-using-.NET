   M S B A M L   `   `   `  ����T  PMembershipMaintenanceMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MembershipMaintenanceMVVMMembershipMaintenanceMVVM  5   	   *    $MembershipMaintenanceMVVM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MembershipMaintenanceMVVM     5   	   -   5          �Name$  Fitness_Member��5   	    � Title$ 
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5	   	   �� *MainViewModel+   Locator �� Source# [  .��5      � .+�5   
   �� -   5         ��Name$ listBox��5      $
��Left=�6#   $	��243��6>   $��	10,54,0,0q�6K   $	��Top=�6^   $	��354��6v    �� DisplayMemberPath$ GetDisplayText��6�   ��6�   �� *
MemberList+ �� SelectedItem 6�   �� *SelectedMember+�� 5   
   -   5         ��Name$ customerLabel��5      $��Member:��6'   $
��Left=�69   $��	10,28,0,0q�6T   $	��Top=�6g   �� 5   
   -   5         ��Name$ 	addButton��5      $	��Add��6$   $
��Left=�62   $��
402,54,0,0q�6M   $	��Top=�6a   $��76��6y   ��6�   �� *AddMemberCommand+�� 5   
   -   5        $ 	delButton��5      $��Delete��6$   $
��Left=�65   $��403,130,0,0q�6P   $	��Top=�6e   $��75��6}   ��6�   �� *DelMemberCommand+�� 5   
   -   5        $ 
exitButton��5      $
��Exit��6%   $
��Left=�64   $��403,168,0,0q�6O   $	��Top=�6d   $��75��6|   ��6�   �� *ExitCommand+�� 5   
   -   5        $ Update��5      $��Update��6!   $
��Left=�62   $��
403,91,0,0q�6M   $	��Top=�6a   $��75��6y   ��6�   �� *UpdateCommand+5      5      