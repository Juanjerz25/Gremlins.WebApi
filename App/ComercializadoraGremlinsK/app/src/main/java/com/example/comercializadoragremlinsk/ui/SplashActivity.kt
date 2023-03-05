package com.example.comercializadoragremlinsk.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.CountDownTimer

class SplashActivity : AppCompatActivity() {

    private lateinit var timer: CountDownTimer

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        timer = object : CountDownTimer(5000,1000){
            override fun onTick(p0: Long) {
                //TODO("Not yet implemented")
            }

            override fun onFinish() {
                openMain()
            }

        }
    }

    override fun onStart() {
        super.onStart()
        timer.start();
    }

    fun openMain(){
        startActivity(Intent(this, MainActivity::class.java))
        this.finish();
    }
}