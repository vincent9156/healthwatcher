   M S B A M L   `   `   `  ����H  DHealthWatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HealthWatcher.BehaviorsHealthWatcher.Behaviors  5   	       HealthWatcher.View.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <
Behaviours%clr-namespace:HealthWatcher.Behaviors     5   	     � Title$  Login��5   	   $	��450��6   $	��350��6#    � 
ResizeMode$ NoResize=�60    � 	Resources 5         sb �� 
TargetName �� TargetProperty g� RepeatBehavior �� Value �� KeyTime  
StyleTitle �� Property	 �� Value  StyleMainGrid
 �� Triggers �� Binding �� Value2  ,HealthWatcher.Behaviors.WindowCloseBehaviour��%  &	        &	 "    &	 b    �� 5   
   .��5      �� $ Title��6,   $ (Label.Content)�6J   $ Forever��6v   .�5	      a� $ HealthWatcher��6)   $ 0:0:0��6?   a� 5
      $ Watch the patients!��6)   $ 0:0:5��6E   a� 5      $ HealthWatcher��6)   $ 0:0:10��6?   5      5      �� 5   
   .�5      ��  � ��
	 ��  �61   5      �� 5   
   
 5      �� 5       6   �� *CloseSignal+ true6?   .a�5      ��  �@ Close	 . 6N   5      5      5      .��5      � -   5         �Name$ LoginWindow��5      
�������$	��400��63   $	��300��6?   #��[ 6L   .+�5   
   �� -   5        $��Title��5      #��[ 6   $��HeathWatcher��6A   $
��42.4��6X   $	��Top=�6f   $��12,36.8,12,0q�6~   $��Center=�6�   $��	Pescadero)�6�   $��26(�6�    � Triggers 5      :� 5       :� RoutedEvent$ Label.Loaded��6   [�5      �� 5      #��[  6*   5!      5#      �� 5$   
   -   5        $��LoginTextBlock��5$      $
��Left=�6*   $��84.6,129.6,0,0q�6E   $
��Wrap=�6]   $��Login :��6q   $	��Top=�6�   $��67.043��6�   $��22��6�   �� 5%   
   -   5        $��LoginTextBox��5%      $��155.643,0,110,148.4q�6M    �� TextWrapping$
 Wrap=�6j   $��Bottom=�6~   $��22��6�   ��6&   �� *
Password+ �� Mode$ TwoWay=�6�   �� 5&   
   -   5        $��PasswordTextBlock��5&      $
��Left=�6-   $��84.6,173.8,0,104.24q�6H   $
��Wrap=�6e   $��
Password :��6y   $��67.043��6�   $��22��6�   �� 5'   
   -   5        $��PasswordTextBox��5'       � ToolTip$ Password��6)   $��155.643,173.8,110.023,0q�6`   $
 Wrap=�6�   $	��Top=�6�   $��22��6�   ��6<   �� *Login+$ TwoWay=�6�   �� 5(   
   -   5        $��ButtonSubmit��5(      $��Submit��6%   $��156,0,169,58q�66   $��Bottom=�6L   ��6g   �� *LoginCommand+�� 5)   
   -   5        $��TextBlockLoginFail��5)   z   
���  ��$��28��6@   $
��Left=�6L   $��	85,96,0,0q�6g   $	��Top=�6�   $	��205��6�   ��6%   �� *	LoginFail+6�   5*      5+      