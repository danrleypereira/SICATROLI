import React from 'react'
import './Button.css'

export default function Button(props) {
  const handleClick = () => {
    window.location.href = props.link
  }
  return (
    <section className='homeButton'>
        <button onClick={handleClick} style={{width:props.width, height:props.width,fontSize: props.fontSize}}>{props.name}</button>
    </section>
  )
}
