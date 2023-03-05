package com.example.comercializadoragremlinsk.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import com.example.comercializadoragremlinsk.R
import com.example.comercializadoragremlinsk.io.ApiService
import com.example.comercializadoragremlinsk.io.response.LoginResponse
import com.example.comercializadoragremlinsk.model.UserInfo
import com.example.comercializadoragremlinsk.model.Usuario
import com.example.comercializadoragremlinsk.util.CriptoHelper
import com.example.comercializadoragremlinsk.util.PreferenceHelper
import com.example.comercializadoragremlinsk.util.PreferenceHelper.get
import com.example.comercializadoragremlinsk.util.PreferenceHelper.set
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MainActivity : AppCompatActivity() {

    private val apiservice : ApiService by lazy {
        ApiService.create()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main);

        val preferences = PreferenceHelper.defaultPrefs(this)
        //preferences.get("session", false)
        if (preferences["session", false]){
            go_to_menu()
        }

        val btnIniciarSesion = findViewById<Button>(R.id.btn_iniciar_sesion);
        btnIniciarSesion.setOnClickListener{
            performLogin()
        }
    }

    private fun go_to_menu(){
        val i = Intent(this, MenuActivity::class.java)
        startActivity(i)
        this.finish()
    }

    private fun CreateSessionPreferences(user : Usuario){
        val preferences = PreferenceHelper.defaultPrefs(this)
        preferences["session"] = true
        preferences["idUsuario"] = user.idUsuario
        preferences["nombre"] = user.nombre
        preferences["idRol"] = user.idRol
    }

    private fun performLogin(){
        val txtEmail = findViewById<EditText>(R.id.txt_email).text.toString();
        val txtPassword = findViewById<EditText>(R.id.txt_password).text.toString();

        val passEncrypt = CriptoHelper.encriptar(txtPassword, CriptoHelper.SEED).trimEnd()
        //println(txtEmail)
        //println(passEncrypt)

        val user = UserInfo( correo = txtEmail, contrasena = passEncrypt)
        val call = apiservice.postLogin(user)
        call.enqueue(object: Callback<LoginResponse> {
            override fun onResponse(call: Call<LoginResponse>, response: Response<LoginResponse>) {
                if (response.isSuccessful){
                    val loginResponse = response.body()
                    if (loginResponse == null){
                        Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
                    }
                    else{
                        if (loginResponse.successful){
                            CreateSessionPreferences(loginResponse.result)
                            go_to_menu()
                        }
                        else{
                            Toast.makeText(applicationContext, "Las credenciales son incorrectas", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
                else{
                    Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<LoginResponse>, t: Throwable) {
                Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
            }
        })

    }
}