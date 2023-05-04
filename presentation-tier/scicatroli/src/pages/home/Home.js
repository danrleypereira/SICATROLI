import React, { useState } from 'react'
import './Home.css'
import { Link } from 'react-router-dom';
import  Button from '../../components/atoms/button/Button'
import IdInput from '../../components/atoms/idInput/IdInput'


export default function Home() {

  const [id, setId] = useState('');

  const getId = (id) =>{
    setId(id)
  }

  return (
    <section className='homeBody'>
      <section id='button' className='homeButtons hide'>
        {id === 'teste' && <Link to='/genre'><Button name='UNITE BOOK' width="200px" fontSize="3rem"/></Link>}
        {id === 'teste' && <Link to=''><Button name='SWAP BOOK' width="200px" fontSize="3rem"/></Link>}
      </section>
      <IdInput getId={getId}/>
    </section>
  )
}
