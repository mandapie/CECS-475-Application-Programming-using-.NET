   M S B A M L   `   `   `  ����T  PMembershipMaintenanceMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MembershipMaintenanceMVVM.ViewMembershipMaintenanceMVVM.View  5   	   7    1MembershipMaintenanceMVVM.View.UpdateMemberWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:MembershipMaintenanceMVVM.View     5   	     � Title$  UpdateMemberWindow��5   	   $��219.394��6$   $	��300��65    � DataContext 5	   	   �� *UpdateMemberViewModel+   Locator �� Source# [  .��5
      � .+�5   
   �� -   5         ��Name$ 	fNameText��5      $��First Name:��6#   $
��Left=�69   $��	23,31,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ 	lNameText��5      $��
Last Name:��6#   $
��Left=�68   $��	24,62,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ 	emailText��5      $��Email:��6#   $
��Left=�64   $��	24,93,0,0q�6O   $	��Top=�6b   �� 5   
   -   5         ��Name$ fNameBox��5      $
��Left=�6$   $��23��6?   $��
109,31,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��147��6�   ��6s   �� *	FNameText+6�   �� 5   
   -   5        $ lNameBox��5      $
��Left=�6$   $��23��6?   $��
109,65,0,0q�6K   $
 Wrap=�6_   $	��Top=�6�   $	��147��6�   ��6s   �� *	LNameText+6�   �� 5   
   -   5        $ emailBox��5      $
��Left=�6$   $��23��6?   $��
109,96,0,0q�6K   $
 Wrap=�6_   $	��Top=�6�   $	��147��6�   ��6s   �� *	emailText+6�   �� 5   
   -   5         ��Name$ 
saveButtom��5      $��Update��6%   $
��Left=�66   $��
81,147,0,0q�6Q   $	��Top=�6e   $��75��6}   ��6�   �� *UpdateCommand+�� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��181,147,0,0q�6S   $	��Top=�6h   $��75��6�   ��6�   �� *CancelCommand+5      5      