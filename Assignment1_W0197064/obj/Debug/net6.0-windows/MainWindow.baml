   M S B A M L   `   `   `  ����O  KAssignment1_W0197064, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Assignment1_W0197064Assignment1_W0197064  5   	   %    Assignment1_W0197064.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Assignment1_W0197064     5   	     � Title$  
MainWindow��5   	   $	��460��6   $	��750��6)   ���	#FF949494 J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ ApplicationCommands.Open��5
      5        5   
   -   5        $ ApplicationCommands.Save��5      5        5   
   -   5        $ ApplicationCommands.Close��5      5        5   
   -   5        $ MediaCommands.Play��5      5        5   
   -   5        $ MediaCommands.Pause��5      5        5   
   -   5        $ MediaCommands.Stop��5      5       � 	Resources 5      ��%    5      .��5       � $��0,0,0,0q�6    � ColumnDefinitions 5!   
   �� 5"      $	��300 �6   �� 5#      $	��500 �6    � RowDefinitions 5%   
   �� 5&      $��22 �6   �� 5'      $	��352 �6   �� 5(      $��50 �6   .+�5*   
   ]� $��0��6   $��2��6!   $��0,0, 0,0q�65   .+�5+      o� $	��Top=�6   $	��800��6(   .@�5,      m� $
��File��6   .@�5-      m� $
��Open��6    m� Command$ ApplicationCommands.Open��5.      m� 5/      $
��Save��6   $ ApplicationCommands.Save��50      �� 51      m� 52      $
��Exit��6   $ ApplicationCommands.Close��53      54      m� 55      $��Playback��6   .@�56      m� $
��Play��6   $ MediaCommands.Play��57      m� 58      $��Pause��6   $ MediaCommands.Pause��59      m� 5:      $
��Stop��6   $ MediaCommands.Stop��5;      5<      5=      5>      �� 5?   
   -   5         ��Name$ AlbumImageBlock��5?      $��1��5@      $��1��5A      $y�Hidden=�5B      $��Stretch=�5C      &    Assignment1_W0197064.AudioPlayer  5D   
   -   5          Name$ MainAudioPlayer��5D      $��3��5E      $��1��5F      $��70,0,0,0q�5G      $��2��5H      $y�Hidden=�5I      $��Right=�5J      $   Assignment1_W0197064.TagEditor  5K   
   -	   5        	  Name$	 MainTagEditor��5K      $��1��5L      $��0��5M      $��2��5N      $y�Hidden=�5O      5P      5Q      