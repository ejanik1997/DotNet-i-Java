package com.company;
import java.awt.*;
import javax.swing.*;
import java.util.Random;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class MyApp extends JFrame implements MouseListener {
    JPanel myPane = new JPanel();
    JButton myButton = new JButton("Click");

    MyApp()
    {
        super("MyWindow");
        setBounds(100,100,800,600);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Container con = this.getContentPane();
        con.add(myPane);
        myPane.setSize(800, 600);
        myButton.setMnemonic('P');
        myPane.add(myButton);
        myButton.requestFocus();
        myButton.addMouseListener(this);
    }

    public void mouseClicked(MouseEvent e)

    {
        Random r = new Random();
        myButton.setLocation(r.nextInt(700), r.nextInt(500));
    }

    public void mouseExited(MouseEvent e) {}
    public void mousePressed(MouseEvent e) {}
    public void mouseReleased(MouseEvent e) {}
    public void mouseEntered(MouseEvent e) {}
}
