   M S B A M L   `   `   `  ����@  <Lab01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab01Lab01  5   	       Lab01.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab01     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� $��20q�6   ��6   �� *Items+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $	��100��6?   ��6$   ��  �� Path$
 Name�6?   �� 5      $	��100��6>   ��6$   �� $	 Age�6>   �� 5      $��Center=�6    $��Center=�6=    �� BitmapScalingMode$ HighQuality=�6X   $��50��6�   $��50��6�   ��6�   �� $ PersonImage�6�   5      5      5      �� 5   
   $��1��6   $��20.2,250,19.6,20q�6%   $ Vertical=�6?   .+�5      �� $
��Wrap=�6   $
��Name��6,   �� 5      -   5        $��nameTextBox��5      $��23��6*    �� TextWrapping$
 Wrap=�66   $��	Jarosław��6J   $��0,0,0,10q�6Z   �� 5      $
��Wrap=�6   $	��Age��6,   �� 5      -   5        $��
ageTextBox��5      $��23��6(   $
 Wrap=�64   $��99��6H   $��0,0,0,10q�6S   �� 5      -   5        $��addNewPersonButton��5      $��Add new person��61   6J   �� 5      -   5         ��Name$ addImageButton��5      $��	Add image��6-   $��
0,0,-0.2,0q�6A   6U   5       �� 5!   
   -   5         ��Name$ image��5!      $��1��6   $
��Left=�6/   $	��225��6J   $��92.2,25,0,0q�6W   $	��Top=�6l   $	��225��6�   5"      5#      