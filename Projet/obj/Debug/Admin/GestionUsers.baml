   M S B A M L   `   `   `  ����
  Projet    Projet.GestionUsers   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ GestionUsers��5      $	��640��5      $	��480��6   .��5	      � ���	#FFD8CCCC.+�5
      &   System.Windows.Controls.DataGrid  -   5        $��userDG��5
   )      AutoGenerateColumns .  $��45,73,60,105q�67      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ اسم المستخدم��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *
userName+  5       . $ كلمة المرور��60    6E   �� *MDP+  5       . $ المجموعة��60    6B   �� *
grp.nomGrp+5      �� 5      -   5        $��majBT��5      $��
تعديل��6   $��Right=�6(   $��24��6D   $��
0,0,172,59q�6P   $��Bottom=�6d   $��73��6   �� 5      -   5        $��suppBT��5      $��مسح��6   $��24��6'   $��
0,0,278,59q�63   $��Bottom=�6G   $��Right=�6b   $��70��6~   �� 5      -   5        $��addBT��5      $��
اضافة��6   $
��Left=�6(   $��24��6C   $��
170,0,0,59q�6O   $��Bottom=�6c   $��69��6~   �� 5      $%��لائحة المستخدمين��6
   $��34��6%   $��248,24,237,0q�61   $	��Top=�6G   $��18.667(�6_   5      5      