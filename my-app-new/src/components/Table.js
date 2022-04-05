import React from 'react';

const Table = ({ foods }) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          { (foods.length > 0) ? foods.map( (food, index) => {
             return (
              <tr key={ index }>
                <td>{ food.id }</td>
                <td>{ food.name }</td>
              </tr>
            )
           }) : <tr><td colSpan="3">Loading...</td></tr> }
        </tbody>
      </table>
    );
  }

export default Table