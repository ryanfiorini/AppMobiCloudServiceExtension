   M S B A M L   `   `   `  ����c  _AppMobiCloudServiceExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cd40ca2f993c361[2clr-namespace:appMobi.AppMobiCloudServiceExtension$appMobi.AppMobiCloudServiceExtension  5      4    .appMobi.AppMobiCloudServiceExtension.MyControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:appMobi.AppMobiCloudServiceExtension     5      -   5          >�Name$  MyToolWindow��5         VsBrush.Window#���   5        VsBrush.WindowText#���  5       � 	Resources 5        Link �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	       �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ Center=�64   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ��  �6+   �� 5       � ��
 ���� 6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��	Underline{�6$   #��z��5      #��z��5       5      P� 5       � �� . . �5   "   ��  � ��
 �  ��6?   5      5      5       5!      5"      .��5#      � .+�5$   
   �� 	 �� Orientation$	 Vertical=�6   .+�5%      �� $��10q�6   $��Center=�6$   �� 6B   $'�!appMobi Cloud Service Tool Window��6F   6r   �� 5'      $	 
Horizontal=�6   .+�5(      �� $��10q�6   $
��Bold"�6(   $��Italic$�6:   �� 6N   $�Sign into appHub��6R   6m   �� 5)      -   5        
 ��Name$
 btnGotoApphub��5)   /   $��	10,10,0,0q�6   �� 6G   -   5        .�5)   n   �� $�Goto appHub��6r   6�   6�   �� 5*      -   5        $
 btnWindowsLive��5*   /   $��	20,10,0,0q�6   �� 6H   -   5        .�5*   p   �� $�Login windows live��6t   6�   6�   5+      5,      �� 5-   
   -   5         ��Name$ 	grpSignin��5-      $��0,70,0,0q�6&   
������ $y�Visible=�6R   .��5.      �� .+�5/      �� $	 
Horizontal=�6   .+�50      �� $��5q�6    �� 6,   $�	Username:��60   6D   �� 51      -   5         ��Name$ txtUserName��51      $	��165��63   $��6,0,0,0q�6?   52      �� 54      $	 
Horizontal=�6   .+�55      �� $��5q�6    �� 6,   $�	Password:��60   6D   G� 56      -   5         G�Name$ txtPassword��56   "   $	��165��67   $��9,0,0,0q�6C   57      �� 59      -	   5         ��Name$ 	btnSignin��59   O   $��Sign in��6   $��28��6C   $��	52,2,90,0q�6b   �� 5:      -
   5         ��Name$ 
lblMessage��5:   #   $�� ��6   6#   5<      5=      �� 5>   
   -   5        $ 
grpWelcome��5>      $y�Visible=�6'   $��0,70,0,0q�6<   
������ .��5?      �� $	 Vertical=�6   .+�5@      �� $	 
Horizontal=�6   .+�5A      �� $��5q�6    �� 6,   .F�5B      �� $��	Username:��6   5C      6#   �� 5D      $��5q�6    �� 6,   .F�5E      �� -   5        $ lblUserName��5E      $�� ��6*   5F      6#   5G      �� 5H      -   5         ��Name$ cboAppMobiApps��5H       �� DisplayMemberPath$
 Name��6K   ��63   �� 5I      �� 5K      -   5        $ btnDownloadPackage��5K   a   $��Download Package��6   $��28��6U   $��	52,2,90,0q�6}   �� 5M      -   5        $ btnUploadPackage��5M   ]   $��Upload Package��6   $��28��6Q   $��	52,2,90,0q�6w   5N      5O      5P      5Q      