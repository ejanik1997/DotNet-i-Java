import java.awt.*;
import javax.swing.*;
import java.util.Random;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.util.Date;
import java.util.concurrent.TimeUnit;


public class Button extends JFrame implements MouseListener
{
    JPanel pane = new JPanel();
    JButton pressme = new JButton("Press Me");

    Button()        // the frame constructor
    {
        super("Genius Test");
        setBounds(0,0,800,600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container con = this.getContentPane(); // inherit main frame
        con.add(pane);
        pane.setSize(800, 600);
        pressme.setMnemonic('P'); // associate hotkey to button
        pane.add(pressme);
        pressme.requestFocus();
        pressme.addMouseListener(this); //tells listener to listen
        setVisible(true); // make frame visible
    }

    public void mouseClicked(MouseEvent e)
    {
        int x_get, y_get, x_set, y_set, whichSymbol;
        x_get = pressme.getLocation().x;
        y_get = pressme.getLocation().y;
        Random r = new Random();
        whichSymbol = r.nextInt(1000)%4;
        if(whichSymbol==0) {
            do {
                x_set = r.nextInt(800);
                y_set = r.nextInt(600);
            } while (x_get + x_set > 700 || y_get + y_set > 537);
            pressme.setLocation(x_get + x_set, y_get + y_set);
        }
        if(whichSymbol==1) {
            do {
                x_set = r.nextInt(800);
                y_set = r.nextInt(600);
            } while (x_get - x_set < 0 || y_get - y_set < 0);
            pressme.setLocation(x_get - x_set, y_get - y_set);
        }
        if(whichSymbol==2) {
            do {
                x_set = r.nextInt(800);
                y_set = r.nextInt(600);
            } while (x_get + x_set > 700 || y_get - y_set < 0);
            pressme.setLocation(x_get + x_set, y_get - y_set);
        }
        if(whichSymbol==3) {
            do {
                x_set = r.nextInt(800);
                y_set = r.nextInt(600);
            } while (x_get - x_set < 0 || y_get + y_set > 537);
            pressme.setLocation(x_get - x_set, y_get + y_set);
        }
        /*int  staryy, staryx;
        staryy = pressme.getLocation().y;
        staryx = pressme.getLocation().x;
        for(int i = 0; i<100; i++)
        {
            try
            {
                Thread.sleep(1000);
                pressme.setLocation(staryx + i/10, staryy + i/10);

            } catch (InterruptedException d)
            {
                System.err.format("IOException: %s%n", e);
            }
        }*/
    }

    public void mouseExited(MouseEvent e) {}
    public void mousePressed(MouseEvent e) {}
    public void mouseReleased(MouseEvent e) {}
    public void mouseEntered(MouseEvent e)
    {

    }

    public static void main(String args[])
    {
        new Button();
    }
}

