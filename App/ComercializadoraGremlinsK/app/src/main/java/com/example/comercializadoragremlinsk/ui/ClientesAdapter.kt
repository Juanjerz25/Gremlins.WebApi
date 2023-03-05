package com.example.comercializadoragremlinsk.ui

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.comercializadoragremlinsk.R
import com.example.comercializadoragremlinsk.model.Cliente

class ClientesAdapter(private val clientes: ArrayList<Cliente>) : RecyclerView.Adapter<ClientesAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView){
        val tv_idCliente = itemView.findViewById<TextView>(R.id.tv_id_cliente)
        val tv_tipoDocumento = itemView.findViewById<TextView>(R.id.tv_tipodoc_cliente)
        val tv_numeroDocumento = itemView.findViewById<TextView>(R.id.tv_numerodoc_cliente)
        val tv_nombreCompleto = itemView.findViewById<TextView>(R.id.tv_nombre_cliente)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        return ViewHolder(
            LayoutInflater.from(parent.context).inflate(R.layout.item_cliente, parent, false)
        )
    }

    override fun getItemCount() = clientes.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val cliente = clientes[position]

        holder.tv_idCliente.text = cliente.idCliente.toString()
        holder.tv_tipoDocumento.text = cliente.tipoDocumento
        holder.tv_numeroDocumento.text = cliente.numeroDocumento
        holder.tv_nombreCompleto.text = cliente.nombreCompleto
    }
}