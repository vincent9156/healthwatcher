   M S B A M L   `   `   `  ����H  DHealthWatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HealthWatcher.BehaviorsHealthWatcher.Behaviors  5   	   !    HealthWatcher.View.Patients   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6dg-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   6
Behaviours%clr-namespace:HealthWatcher.Behaviors  5   	     � Title$  Patients��5   	   $	��600��6   $	��600��6'    � 
ResizeMode$ NoResize=�63    � 	Resources 5         
StyleTitle �� Property �� Value  dtObservationList �� Orientation  dtPictureList  StyleMainGrid �� Triggers �� Binding �� Value2  ,HealthWatcher.Behaviors.WindowCloseBehaviour��%�  &	        &	 @     &	 �     &	     �� 5   
   .�5	      ��  � ��
 ��  �61   5
      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� *Date+5      5      �� 5   
   .R�5      �� $	��120��6.   $	��120��6:   ��6   �� *Source+6:   5      �� 5   
    5      �� 5       6   �� *CloseSignal+ true6?   .a�5      ��  �@ Close . 6N   5      5      5      .��5      � #��[ 6   	 � ColumnDefinitions	 5   
   �� 5      $	��178 �6   �� 5      $	��20* �6   �� 5       $
��100* �6   �� 5!      $	��11* �6   �� 5"      $
��129* �6   �� 5#      $	��11* �6   �� 5$      $	��60* �6   �� 5%      $	��10* �6   �� 5&      $	��60* �6   
 � RowDefinitions
 5(   
   �� 5)      $��32 �6   �� 5*      $��10 �6   �� 5+      $��32 �6   �� 5,      $��32 �6   �� 5-      $��10 �6   �� 5.      $��64 �6   �� 5/      $	��10* �6   �� 50      $	��30* �6   �� 51      $	��30* �6   �� 52      $
��311* �6   .+�54   
   �� -   5        $��PatientsLabel��54   n   #��[  6   $��Patients��64   $��32��6G   $
��Left=�6S   $	��Top=�6�   $	��178��6�   $��20(�6�   $��Center=�6�   �� 55   
   -   5        $	��Add��55   D   $��+��6   $��32��6   $
��Left=�6)   $	��Top=�6O   $��89��6g   $��20(�6r   $��2��6�   ��6�   �� *AddPatientCommand+{�6�   �� *	UserRight+�� 56   
   -   5        $��Remove��56   E   $��-��6   $��32��6   $��Right=�6)   $	��Top=�6S   $��89��6k   $��20(�6v   $��2��6�   ��6�   �� *RemovePatientCommand+{�6�   �� *	UserRight+)  #Microsoft.Windows.Controls.DataGrid  57   
   $��3��6   $��7��6#      AutoGenerateColumns .  $��0,0,0,12q�6�   ��64   �� *
Patients+ �� SelectedItem 6U   �� *SelectPatient+ �� Mode$ TwoWay=�   Columns 58      3  -Microsoft.Windows.Controls.DataGridTextColumn  59      /  )Microsoft.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��6:      MaxWidth$ 40Q�6]      MinWidth$ 40Q�6k   4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Id+6k     5:       . $
 Name��6:   $ 70Q�6a   $ 70Q�6o    6H   �� *Name+6o     5;       . $ 	Firstname��6:   $ 70Q�6k   $ 70Q�6y    6M   �� *	Firstname+6y   7  1Microsoft.Windows.Controls.DataGridTemplateColumn  5<      $ Birthday��6,    .    CellTemplate 5=      �� 5>      .R�5?      �� ��6(   �� *
Birthday+5@      5B      5D      �� 5E   
   -   5        $��ObservationLabel��5E   �   #��[  6   $��Observations��64   $��2��6K   $��32��6[   $
��Left=�6g   $	��Top=�6�   $	��380��6�   $��20(�6�   $��Center=�6�   $��7��6�   �� 5F   
   -   5        $��AddObservation��5F   a   $��+��6   $��2��6   $��2��6-   $��32��6:   $
��Left=�6F   $	��Top=�6w   $	��100��6�   $��20(�6�   ��6�   �� *AddObservationCommand+{�6�   �� *	UserRight+�� 5G   
   -   5        $��ObservationList��5G   W   $��2��6   $��3��6"   $	��475��6/   $
��Left=�6<   $	��Top=�6n   $��99��6�   $��7��6�   #��[ 6�   ��6�   �� *SelectPatient.Observations+ 6  �� *SelectObservation+�� 5H   
   -   5        $��PictureList��5H   W   $��4��6   $��2��6"   $	��140��6/   $
��Left=�6<   $	��Top=�6j   $	��140��6�   $��3��6�   #��[ 6�   $��5��6  $
��Left=�6  ��6�   �� *SelectObservation.Pictures+6  �� 5I   
   -   5        $��BloodPressureLabel��5I   �   $��Blood Pressure :��6   $��3��6+   $��7��6;   $��30��6H   $
��Left=�6T   $��11,0,0,0q�6o   $	��Top=�6�   $��3��6�   $	��129��6�   �� 5J   
   -	   5        $��BloodPressureTextBlock��5J   X   $��5��6   $��7��6$   $��30��61   $
��Left=�6=   $	��Top=�6v   $��4��6�   $	��141��6�   ��6�   �� *!SelectObservation.BloodPressure+�� 5K   
   -
   5        $��WeightLabel��5K   x   $��Weight :��6   $��4��6#   $��8��63   $��30��6@   $
��Left=�6L   $��1,0,0,0q�6g   $	��Top=�6�   $	��127��6�   �� 5L   
   -   5        $��WeightTextBlock��5L   X   $��5��6   $��8��6$   $��30��61   $
��Left=�6=   $	��Top=�6o   $��4��6�   $	��141��6�   ��6�   �� *SelectObservation.Weight+�� 5M   
   -   5        $��CommentTextBlock��5M   Y   $��4��6   $��9��6$   $	��299��61   $
��Left=�6>   $	��Top=�6q   $	��162��6�   $��	108,0,0,0q�6�   $��5��6�   ��6�   �� *SelectObservation.Comment+6�   �� 5N   
   -   5        $��textBoxPrescription��5N   h   $��4��6   $��9��6"   $	��299��6/   $
��Left=�6<   $��2,0,0,0q�6W   $	��Top=�6�   $	��100��6�   ��6�   �� * SelectObservation.Prescription+�� 5O   
   -   5        $��
rectangle1��5O   Y   $��6��6   $��2��6$   $	��138��61   $
��Left=�6>   
���   �$	��Top=�6z   $��50��6�   
����p��$��10,0,0,0q�6�   $��4��6�   �� 5P   
   -   5        $��
rectangle2��5P   Y   $��8��6   $��2��6$   $	��138��61   $
��Left=�6>   
���   �$	��Top=�6z   $��50��6�   
������$��4��6�   5Q      5R      