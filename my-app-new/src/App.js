import React, { Component } from 'react';
import Table from './components/Table.js';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      foods: []
    }
  }

  componentDidMount() {
  	fetch('http://localhost:5259/Food?format')
  	.then(res => res.json())
  	.then(json => json.foods)
  	.then(foods => this.setState({ 'foods': foods }))
  }

  render() {
    return (
      <div className="App">
        <Table foods={ this.state.foods } />
      </div>
    );
  }
}

export default App;
