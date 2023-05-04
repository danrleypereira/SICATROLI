import React, {useState} from 'react'
import './IdInput.css'

export default function IdInput({getId}) {
    
    const[id, setId] = useState('');

    const handleId = (e) =>{
        setId(e.target.value);
        getId(id);
        if(id === 'teste'){
            document.getElementById('button').classList.remove('hide')
            document.getElementById('button').classList.add('show')
          }else{
            document.getElementById('button').classList.remove('show')
            document.getElementById('button').classList.add('hide')
          }
    }
    
  return (
    <section className='homeInput'>
        <input value={id} onChange={handleId} onBlur={handleId} type='text' placeholder='' />
    </section>
  )
}
