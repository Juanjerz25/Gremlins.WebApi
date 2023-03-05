package com.example.comercializadoragremlinsk.ui

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.core.view.isVisible
import com.example.comercializadoragremlinsk.R
import com.example.comercializadoragremlinsk.util.PreferenceHelper
import com.example.comercializadoragremlinsk.util.PreferenceHelper.get
import com.example.comercializadoragremlinsk.util.PreferenceHelper.set

class MenuActivity : AppCompatActivity() {
    @SuppressLint("SetTextI18n")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_menu)

        val btnCerrarSesion = findViewById<Button>(R.id.btn_cerrar_sesion);
        val btnVentas = findViewById<Button>(R.id.btn_ventas);
        val btnClientes = findViewById<Button>(R.id.btn_clientes);
        val btnDistribuidores = findViewById<Button>(R.id.btn_distribuidores);
        val btnProductos = findViewById<Button>(R.id.btn_productos);
        val btnUsuarios = findViewById<Button>(R.id.btn_usuarios);
        val lblUser = findViewById<TextView>(R.id.lbl_user);

        btnCerrarSesion.setOnClickListener{
            ClearSessionPreferences()
            logout()
        }

        btnVentas.setOnClickListener{
            ventas()
        }

        btnClientes.setOnClickListener{
            clientes()
        }

        btnDistribuidores.setOnClickListener{
            distribuidores()
        }

        btnProductos.setOnClickListener{
            produtos()
        }

        btnUsuarios.setOnClickListener{
            usuarios()
        }
        val preferences = PreferenceHelper.defaultPrefs(this)
        lblUser.text = "Usuario : " + preferences["nombre", ""]
        val rol = preferences["idRol", 1]

        if(rol == 2){
            btnVentas.isVisible = false
            btnClientes.isVisible = true
            btnDistribuidores.isVisible = true
            btnProductos.isVisible = false
            btnUsuarios.isVisible = true
        }

        if(rol == 3){
            btnVentas.isVisible = true
            btnClientes.isVisible = true
            btnDistribuidores.isVisible = true
            btnProductos.isVisible = true
            btnUsuarios.isVisible = false
        }

        if(rol == 4){
            btnVentas.isVisible = true
            btnClientes.isVisible = false
            btnDistribuidores.isVisible = false
            btnProductos.isVisible = false
            btnUsuarios.isVisible = false
        }

        if(rol == 5){
            btnVentas.isVisible = false
            btnClientes.isVisible = true
            btnDistribuidores.isVisible = true
            btnProductos.isVisible = false
            btnUsuarios.isVisible = false
        }

    }

    private fun logout(){
        val i = Intent(this, MainActivity::class.java)
        startActivity(i)
        //this.finish();
    }

    private fun ClearSessionPreferences(){
        val preferences = PreferenceHelper.defaultPrefs(this)
        preferences["session"] = false
        preferences["idUsuario"] = 0
        preferences["nombre"] = ""
        preferences["idRol"] = 0
    }

    override fun onBackPressed() {
        super.onBackPressed()

    }

    private fun ventas(){

    }

    private fun clientes(){
        val i = Intent(this, ClientesActivity::class.java)
        startActivity(i)
    }

    private fun distribuidores(){

    }

    private fun produtos(){

    }

    private fun usuarios(){

    }

}