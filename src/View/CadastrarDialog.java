package View;

import javax.swing.*;
import java.awt.*;
class CadastrarDialog extends JFrame
{
JDialog d1;

    public CadastrarDialog()
    {
        createAndShowGUI();
    }
    
    private void createAndShowGUI()
    {
        setTitle("SICATROLI Cadastrar");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(new FlowLayout());

        // Must be called before creating JDialog for
        // the desired effect
        JDialog.setDefaultLookAndFeelDecorated(true);
        
        // A perfect constructor, mostly used.
        // A dialog with current frame as parent
        // a given title, and modal
        d1=new JDialog(this,"This is title",true);
        
        // Set size
        d1.setSize(400,400);
        
        // Set some layout
        d1.setLayout(new FlowLayout());
        
        d1.add(new JButton("Button"));
        d1.add(new JLabel("Label"));
        d1.add(new JTextField(20));
        
        setSize(400,400);
        setVisible(true);
        
        // Like JFrame, JDialog isn't visible, you'll
        // have to make it visible
        // Remember to show JDialog after its parent is
        // shown so that its parent is visible
        d1.setVisible(true);
    }
}