import React from 'react'
import './Genre.css'

import Button from '../../components/atoms/button/Button'
import IdInput from '../../components/atoms/idInput/IdInput'

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
        <Button name='HISTORY' width={width} fontSize={fontSize}/>
        <Button name='DICTIONARY' width={width} fontSize={fontSize}/>
        <Button name='IT' width={width} fontSize={fontSize}/>
        <Button name='LITERATURE' width={width} fontSize={fontSize}/>
        <Button name='SCIENCE' width={width} fontSize={fontSize}/>
      </section>
      <section className='genreButtons'>
        <Button name='ESOTERISM' width={width} fontSize={fontSize}/>
        <Button name='FICTION' width={width} fontSize={fontSize}/>
        <Button name='REFERENCES' width={width} fontSize={fontSize}/>
        <Button name='SELF HELP' width={width} fontSize={fontSize}/>
        <Button name='DIDACTIC' width={width} fontSize={fontSize}/>
      </section>
    </section>
  )
}
