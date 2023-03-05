package com.example.comercializadoragremlinsk.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.comercializadoragremlinsk.R
import com.example.comercializadoragremlinsk.io.ApiService
import com.example.comercializadoragremlinsk.io.response.ClientesResponse
import com.example.comercializadoragremlinsk.io.response.LoginResponse
import com.google.android.material.floatingactionbutton.FloatingActionButton
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ClientesActivity : AppCompatActivity() {

    private val apiservice : ApiService by lazy {
        ApiService.create()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_clientes)

        val fab = findViewById<FloatingActionButton>(R.id.fab_add);
        fab.setOnClickListener {
            AddCliente()
        }
        getClientes()
    }

    private fun AddCliente(){
        val i = Intent(this, ClienteActivity::class.java)
        startActivity(i)
    }


    private fun getClientes(){
        val rvClientes = findViewById<RecyclerView>(R.id.rv_clientes)

        val call = apiservice.getClientes()
        call.enqueue(object: Callback<ClientesResponse> {
            override fun onResponse(call: Call<ClientesResponse>, response: Response<ClientesResponse>) {
                if (response.isSuccessful){
                    val clientesResponse = response.body()
                    if (clientesResponse == null){
                        Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
                    }
                    else{
                        if (clientesResponse.successful){
                            //fill list
                            rvClientes.adapter = ClientesAdapter(clientesResponse.result)
                        }
                        else{
                            Toast.makeText(applicationContext, "Error con la consulta de los clientes", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
                else{
                    Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<ClientesResponse>, t: Throwable) {
                Toast.makeText(applicationContext, "Se produjo un error en el servidor", Toast.LENGTH_SHORT).show()
            }
        })
        rvClientes.layoutManager = LinearLayoutManager(this)
    }
}