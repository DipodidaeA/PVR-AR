import express from 'express';
const app = express()
const port = 3000

app.get('/', (req, res) => {
    res.send(`Hello`);
})

function Random(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

app.get('/weather', (req, res) => {
    let temperature = Random(-20, 20);
    res.json({ temp: temperature });
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})
