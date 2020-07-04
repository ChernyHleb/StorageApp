using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StoreApp.ViewModels;

namespace StoreApp.Commands
{
    class CRUDCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ViewModels.ViewModelBase _viewmodel;

        public CRUDCommand(ViewModelBase viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Add")
            {
                Views.InsertItemPage window = ((Views.InsertItemPage)_viewmodel.childWindow);
                string ItemTitle = window.TextBox_ItemTitle.Text;
                int ItemPrice = Convert.ToInt32(window.TextBox_ItemPrice.Text);

                DbModel.Item NewItem = new DbModel.Item
                {
                    Title = ItemTitle,
                    Price = ItemPrice,
                    CategoryId = 1,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                };

                using (var context = new DbModel.CodeFirstContext())
                {
                    Services.GenericCRUD<DbModel.Item> ItemsCRUD = new Services.GenericCRUD<DbModel.Item>(context);
                    ItemsCRUD.Create(NewItem);
                    
                }
                _viewmodel.FilterGridCommand.Execute("Assepted");
            }
            else if(parameter.ToString() == "MoveOnStore")
            {
                Views.MoveItemToStoreView window = ((Views.MoveItemToStoreView)_viewmodel.childWindow);
                DbModel.Item SelectedItem = (DbModel.Item)window.ComboBox_ItemSelector.SelectedItem;
                /// Correct UPDATING !
                using (var context = new DbModel.CodeFirstContext())
                {
                    var item = context.Items.Where(i => i.ItemId == SelectedItem.ItemId).FirstOrDefault();
                    item.CategoryId = 2;
                    context.SaveChanges();
                }
                _viewmodel.FilterGridCommand.Execute("Assepted");
            }
            else if (parameter.ToString() == "Sell")
            {
                Views.SellingItemView window = ((Views.SellingItemView)_viewmodel.childWindow);
                DbModel.Item SelectedItem = (DbModel.Item)window.ComboBox_ItemSelector.SelectedItem;
                /// Correct UPDATING !
                using (var context = new DbModel.CodeFirstContext())
                {
                    var item = context.Items.Where(i => i.ItemId == SelectedItem.ItemId).FirstOrDefault();
                    item.CategoryId = 3;
                    context.SaveChanges();
                }
                _viewmodel.FilterGridCommand.Execute("OnStore");
            }

            _viewmodel.childWindow.Close();
        }
    }
}
