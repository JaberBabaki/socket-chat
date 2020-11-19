package com.jaberALU.chatWifi;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.InetSocketAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Calendar;
import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.widget.DrawerLayout;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;


public class WifiChatActivity extends Activity {

    private Handler          handler = new Handler();
    private TextView         textSend;
    private TextView         textRecive;
    private TextView         textOnline;
    private EditText         input;
    private Button           btnSend;
    private Button           btnAttach;
    private Socket           socket;
    private DataOutputStream outputStream;
    private BufferedReader   inputStream;
    private String           fileAddress;


    private boolean searchNetwork() {
        // log("Connecting...");

        String range = "192.168.56.";
        for (int i = 1; i <= 254; i++) {
            String ip = range + i;
            try {
                //log("Try IP: " + ip);
                socket = new Socket();
                socket.connect(new InetSocketAddress(ip, 9000), 10);

                //  log("Connected!");
                showOnline(i + "  online");

                return true;
            }
            catch (Exception e) {
                //Log.i("LLL", e.getMessage());
            }
        }

        return false;
    }


    private void runChatServer() {
        try {
            // log("Waiting for client...");

            ServerSocket serverSocket = new ServerSocket(9000);//جهت اتصال نیاز استفاده از شی و استفاده از پورت هستیم پورت های آزاد
            socket = serverSocket.accept();// تا موقعی که سوکتی را دریافت نکنه در این قطعه از کد میمونه

            showOnline("" + socket.getInetAddress());
            //log("A new client Connected!");
        }
        catch (IOException e) {}
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.maint_root);
        //Log.i("ERO", "Error: Connection is not stable, exit");
        final DrawerLayout drawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        ImageView imgMen = (ImageView) findViewById(R.id.men);
        LinearLayout lay_message = (LinearLayout) findViewById(R.id.lay_message);
        textRecive = (TextView) findViewById(R.id.txt_recive);
        textSend = (TextView) findViewById(R.id.txt_send);
        textOnline = (TextView) findViewById(R.id.txt_online);
        input = (EditText) findViewById(R.id.input);
        btnSend = (Button) findViewById(R.id.btnSend);
        btnAttach = (Button) findViewById(R.id.btn_attach);

        imgMen.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (drawerLayout.isDrawerOpen(Gravity.RIGHT)) {
                    drawerLayout.closeDrawers();
                } else {
                    drawerLayout.openDrawer(Gravity.RIGHT);
                }
            }
        });

        lay_message.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
                intent.setType("*/*");
                startActivityForResult(intent, 1);
                // startActivityForResult(Intent.createChooser(intent, "Select Picture"), 1);
            }
        });
        //server
        Thread thread = new Thread(new Runnable() {// به این دلیل از ترد استفاده کردیم تا برنامه قفل نکنه یعنی ترد اصلی فعال باشه

            @Override
            public void run() {
                if ( !searchNetwork()) {
                    runChatServer();
                }

                try {
                    outputStream = new DataOutputStream(socket.getOutputStream());
                    inputStream = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                }
                catch (IOException e1) {
                    //  log("Error: Connection is not stable, exit");
                    shutdown();
                }

                if (fileAddress != null) {
                    recive();
                } else {
                    while (true) {

                        try {
                            String message = inputStream.readLine();

                            if (message != null) {
                                log(message);
                            }
                        }
                        catch (IOException e) {}
                    }
                }
            }
        });

        btnSend.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (outputStream == null) {
                    return;
                }

                try {
                    String message = input.getText().toString() + "\n";
                    myLog(message);
                    outputStream.write(message.getBytes());
                }
                catch (IOException e) {
                    e.printStackTrace();
                }

            }
        });
        btnAttach.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
                intent.setType("*/*");
                startActivityForResult(intent, 1);
                startActivityForResult(Intent.createChooser(intent, "Select Picture"), 1);

            }
        });

        thread.start();
    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Calendar c = Calendar.getInstance();
        int SECOND = c.get(Calendar.SECOND);
        int MINUTE = c.get(Calendar.MINUTE);
        int HOUR = c.get(Calendar.HOUR);
        final String time = HOUR + ":" + MINUTE + ":" + SECOND;
        if (requestCode == 1 && resultCode == RESULT_OK && data != null && data.getData() != null) {

            Uri uri = data.getData();
            fileAddress = uri.toString();
            Toast.makeText(WifiChatActivity.this, "لطفا منتظر بمانید", Toast.LENGTH_SHORT).show();
            Thread thread = new Thread(new Runnable() {

                @Override
                public void run() {
                    File myFile = new File(fileAddress);
                    while (true) {
                        byte[] mybytearray = new byte[(int) myFile.length()];
                        try {
                            BufferedInputStream bis = new BufferedInputStream(new FileInputStream(myFile));

                            bis.read(mybytearray, 0, mybytearray.length);
                            outputStream.write(mybytearray, 0, mybytearray.length);
                        }
                        catch (IOException e) {
                            // TODO Auto-generated catch block
                            e.printStackTrace();
                        }

                    }
                }
            });
            thread.start();

            String message = " send File " + "\n";
            try {
                outputStream.write(message.getBytes());
            }
            catch (IOException e) {
                // TODO Auto-generated catch block
                log(e.toString());
                e.printStackTrace();
            }
            textSend.setText(textSend.getText() + time + "=> " + message);
            // textSend.setText(textSend.getText() + " send File" + "\n");

        }
    }


    private void log(final String message) {
        // long timestamp = System.currentTimeMillis();
        //final long time = timestamp % 1000000;

        Calendar c = Calendar.getInstance();
        int SECOND = c.get(Calendar.SECOND);
        int MINUTE = c.get(Calendar.MINUTE);
        int HOUR = c.get(Calendar.HOUR);
        final String time = HOUR + ":" + MINUTE + ":" + SECOND;
        int s = 0;
        ;
        if (message.equals("End1373")) {
            showOnline("offline");
            s = 1;
        }
        if (s != 1) {
            handler.post(new Runnable() {

                @Override
                public void run() {
                    textRecive.setText(textRecive.getText() + "\n " + time + "=> " + message);
                    textSend.setText(textSend.getText() + "\n");
                }
            });
        }
    }


    private void myLog(final String message) {
        Calendar c = Calendar.getInstance();
        int SECOND = c.get(Calendar.SECOND);
        int MINUTE = c.get(Calendar.MINUTE);
        int HOUR = c.get(Calendar.HOUR);
        final String time = HOUR + ":" + MINUTE + ":" + SECOND;
        //long timestamp = System.currentTimeMillis();
        // final long time = timestamp % 1000000;

        if (message.equals("End1373")) {
            showOnline("offline");
        }

        handler.post(new Runnable() {

            @Override
            public void run() {
                textSend.setText(textSend.getText() + "\n " + time + "=> " + message);
                textRecive.setText(textRecive.getText() + "\n");
            }
        });
    }


    private void recive() {

        byte[] mybytearray = new byte[1024];
        InputStream is;
        try {
            is = socket.getInputStream();
            FileOutputStream fos = new FileOutputStream(fileAddress);
            BufferedOutputStream bos = new BufferedOutputStream(fos);
            int bytesRead = is.read(mybytearray, 0, mybytearray.length);
            bos.write(mybytearray, 0, bytesRead);
            bos.close();
        }
        catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

    }


    private void showOnline(String message) {
        if (message.equals("offline")) {
            message = textOnline.getText().toString().substring(0, 3) + " " + message;
        }
        if (message.contains("/")) {
            message = message.substring(12, 15);
            message = message + " online";
        }
        final String m = message;
        handler.post(new Runnable() {

            @Override
            public void run() {
                textOnline.setText(m);
            }
        });

    }


    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (keyCode == KeyEvent.KEYCODE_BACK) {
            String message = "End1373" + "\n";
            try {
                outputStream.write(message.getBytes());
            }
            catch (IOException e) {
                // TODO Auto-generated catch block
                log(e.toString());
                e.printStackTrace();
            }
            shutdown();
            return true;
        }

        return super.onKeyDown(keyCode, event);
    }


    private void shutdown() {

        try {

            if (socket != null) {
                socket.close();
            }
        }
        catch (IOException e) {
            e.printStackTrace();
        }
        System.exit(0);
    }
}