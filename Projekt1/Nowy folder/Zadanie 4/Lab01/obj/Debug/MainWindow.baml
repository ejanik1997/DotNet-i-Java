   M S B A M L   `   `   `  ����@  <Lab01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab01Lab01  5   	       Lab01.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab01     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $
��1200��6)    � 	Resources 5	         nasaViewSource  
AddCommand  UpdateCommand  DeleteCommand��%t   &	        &	      &	 &     &	 9     �� 5
   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   5      .��5      �  J� RenderTransformOrigin$ 0.556,0.483&�6   $
��Left=�6/   $��	0,0,0,0.4q�6J   $	��790��6]    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��20,25,328.4,21q�6   $��2��6H   ��6*   �� *Items+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $	��120��6?   ��6$   ��  �� Path$
 Name�6?   �� 5      $��80��6>   ��6$   �� $	 Age�6>   �� 5      $��80��6>   ��6$   �� $	 Lon�6>   �� 5      $��80��6>   ��6$   �� $	 Lat�6>   �� 5      $��Center=�6    $��Center=�6=    �� BitmapScalingMode$ HighQuality=�6X   $��50��6�   $��50��6�   ��6�   �� $ PersonImage�6�   5      5      5       �� 5!   
   $��1��6   $��73.2,250,19.6,20.4q�6%   $ Vertical=�6A   .+�5"      �� $
��Wrap=�6   �� 6-   $
�Date��61   �� 6?   $(�": between 2014-01-01 and 2017-3-31��6C   6p   �� 5#      -   5        $��nameTextBox��5#      $��23��6*    �� TextWrapping$
 Wrap=�66   $��0,0,0,10q�6J   �� 5$      $
��Wrap=�6   �� 6-   $	�Lon��61   �� 6>   $�: must be int between <-��6B   �� 6g   $	�100��6k   �� 6x   $�,��6|   �� 6�   $	�100��6�   �� 6�   $�>��6�   �� 6�   $� for request��6�   6�   �� 5%      -   5        $��
ageTextBox��5%      $��23��6(   $
 Wrap=�64   $��0,0,0,10q�6H   �� 5&      $
��Wrap=�6   $��
0,0,-0.2,0q�6,   �� 6A   $	�Lat��6E   �� 6R   $.�(: must be int between <0,80> for request��6V   6�   �� 5'      -   5        $��
latTextBox��5'      $��23��6)   $
 Wrap=�65   $��0,0,0,10q�6I   �� 5(      -   5         ��Name$ addNewPersonButton��5(      $��Add new entry��63   $��
0,0,-0.2,0q�6l   �� 5)      -   5        $ addImageButton��5)      $��
Load image��6-   $��
0,0,-0.2,0q�6B   6V   �� 5*      -   5        $��Add seven random entries��5*      $��
0,0,-0.2,0q�6M   �� 5+      -   5        $)��#Request entry for current variables��5+      6C   5,      �� 5-   
   -	   5        	 ��Name$	 image��5-      $��1��6   $
��Left=�6/   $	��225��6J   $��152.2,25,0,0q�6W   $	��Top=�6m   $	��225��6�   $ 0.483,0.495&�6�   �� 5.   
   $
��Left=�6   $��20,4,0,0q�6/   $
��Wrap=�6A   $	��Top=�6U   $��2��6m   $	��442��6�   �� 6�   $�Date              ��6�   �� 6�   $�        ��6�   �� 6�   $	�   ��6�   �� 6�   $� ��6�   �� 6�   $�
CloudScore��6�   �� 6�   $�      ��6   �� 6  $� ��6  �� 6  $�  Longitude      ��6#  �� 6>  $� ��6B  �� 6M  $%�    Latitude           SkyImage��6Q  6{  &   System.Windows.Controls.DataGrid  5/   
   $��1��6   $
��Left=�6#   $	��514��6>   $��404.8,35,-343.6,0q�6K   $	��Top=�6f   $	��334��6~   
 � DataContext#
 [  6�   ��6�   ��    Columns 50   
   0  *System.Windows.Controls.DataGridTextColumn  51      -
   5        
dateColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Date��51   N      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Date+6\     52      -   5        CSColumn��$ 
CloudScore��52   R   $ SizeToHeader 6f    63   �� *
CloudScore+6f     53      -   5        
lonCoulumn��$ 	Longitude��53   S   $ SizeToHeader 6f    65   �� *	Longitude+6f     54      -   5        	latColumn��$ Latitude��54   Q   $ SizeToHeader 6c    64   �� *
Latitude+6c     55      -   5        
imagColumn��$ Image��55   O   $ SizeToHeader 6^    65   �� *Image+6^   57      58      59      