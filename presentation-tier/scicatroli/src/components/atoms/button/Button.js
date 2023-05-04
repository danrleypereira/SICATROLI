import React from 'react'
import './Button.css'

export default function Button(props) {
  return (
    <section className='homeButton'>
        <button style={{width:props.width, height:props.width,fontSize: props.fontSize}}>{props.name}</button>
    </section>
  )
}
