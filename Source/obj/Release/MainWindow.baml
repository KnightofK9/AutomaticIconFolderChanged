   M S B A M L   `   `   `  ����   Folder icon changed$    Folder_icon_changed.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$#  Automatic Icon Folder Changed��$	��350��$	��525�� � Icon$1 +/Resources/Send-Receive-All-Folders-128.png��.���  � RowDefinitions �� $��20 ��� $��10 ��� $��4* ��� $��1* ��� $��4* ��� $��1* ��� $��4* ��� $��1* ��� $��4* ��� $��1* ��� $��4* ��� $��10 ��� $��40 � � ColumnDefinitions �� $��10 ��� $��2* ��� $��20 ��� $��* ��� $��10 �.+��� -   $��AnimeFolderPath�� �� 
IsReadOnly . $��1��$��2��
�������$��Center=��� -   $��IconFolderPath�� . $��1��$��4��
������� �� TextAlignment$ Justify=�$��Center=��� -    ��Name$ animeFolderPath��$��3��$��2��   Browse_folder#���     Button_Style_1#��[ �� -   $ iconFolderPath��$��3��$��4��  Browse_icon#���  #��[ �� -   $ Change��
������� 
 Change#���  $��6��$��3��#��[ �� -    ��Name$ Result�� . 
������� �� TextWrapping$
 Wrap=�$�� ��$��1��$��6��$��6���� -   	 ��Name$	 ChangeIfHas��  ChangeIfHas#���    ChangeIfHasTip
 � ToolTip#
 �  $��0.2,10,0.8,10q�$��3��$��8��o� $��0��$��0��$��5��.@�m�   Tool#���  .@�m� -    	 About#���  m� -	    
 Update#���  m� -
    	 HowToUse#��� 	 m�  
 Language#��� 
 .@�m� -    m�Name$ EN_Menu��  English#���   m� IsCheckable .  m� 	IsChecked . m� -   $ VN_Menu��  
Vietnamese#���   . 