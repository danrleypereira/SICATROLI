import React from 'react'
import './Genre.css'

import Button from '../../components/atoms/button/Button'
import IdInput from '../../components/atoms/idInput/IdInput'
import { Link } from 'react-router-dom'

export default function genre() {
  const width = '150px'
  const fontSize = '1.8rem'

  return (
    <section className='genreBody'>
      <section className='genreHeader'>
        <h1>Genre</h1>
        <IdInput/>
      </section>
      <section className='genreButtons'>
        <Button link='/conservation' name='HISTORY' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='DICTIONARY' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='IT' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='LITERATURE' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='SCIENCE' width={width} fontSize={fontSize}/>
      </section>
      <section className='genreButtons'>
        <Button link='/conservation' name='ESOTERISM' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='FICTION' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='REFERENCES' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='SELF HELP' width={width} fontSize={fontSize}/>
        <Button link='/conservation' name='DIDACTIC' width={width} fontSize={fontSize}/>
      </section>
    </section>
  )
}
