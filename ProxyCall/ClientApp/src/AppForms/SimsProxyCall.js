import React, { useState } from 'react'
import axios from 'axios'
import styles from './SimsProxyCall.module.css'

export default function SimsProxyCall() {
  const [result, setResult] = useState(null)
  const [f_loading, setLoadingFlag] = useState(false)
  const [queryArgs, setQueryArgs] = useState({formNo:'F002'})

  function handleQueryForm() {
    setLoadingFlag(true)
    axios({
      method: 'POST',
      url: '/TestForm/QueryForm',
      data: null,
    }).then(resp => {
      setResult(resp.data)
    }).catch(xhr => {
      setResult(xhr)
    }).finally(() => {
      setLoadingFlag(false)
    })
  }

  function handleLoadForm() {
    setLoadingFlag(true)
    axios({
      method: 'POST',
      url: `/TestForm/LoadForm?formNo=${queryArgs.formNo}`,
    }).then(resp => {
      setResult(resp.data)
    }).catch(xhr => {
      setResult(xhr)
    }).finally(() => {
      setLoadingFlag(false)
    })
  }

  return (
    <div className="App">
      <h1>SimsProxyCall</h1>
      {f_loading && <p>LOADING</p>}

      <button className={styles.button}
        onClick={handleQueryForm}
      >Query Form</button>

      <button className={styles.button}
        onClick={handleLoadForm}
      >Load Form</button>

      <button className={styles.button}>
        Save Form</button>

      <button className={styles.button}>
        Long Time Calc</button>

      <div>
        <label>formNo</label>
        <input value={queryArgs.formNo} 
          onChange={e => setQueryArgs({ formNo:e.target.value})} 
        />
      </div>

      <pre>
        <h4>result</h4>
        {JSON.stringify(result, null, '  ')}
      </pre>

    </div>
  );
}

//#region


//#endregion

